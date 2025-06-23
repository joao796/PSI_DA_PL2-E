using iTasks.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks.Controller
{
    class KanbanController
    {
        public string CurrentUsername { get; set; }

        public string GetNomeDoUtilizador(string username)
        {
            using (var context = new iTaskcontext())
            {
                var utilizador = context.Utilizadores
                    .Where(u => u.Username == username)
                    .Select(u => u.Nome)
                    .FirstOrDefault();

                return utilizador; // retorna string ou null se não encontrado
            }
        }

        public bool PodeGerirUtilizadores(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            using (var context = new iTaskcontext())
            {
                return context.Gestores.Any(g => g.Username == username && g.GereUtilizadores);
            }
        }

        public bool PodeCriarTarefa(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            using (var context = new iTaskcontext())
            {
                return context.Gestores.Any(g => g.Username == username);
            }
        }

        public List<Tarefa> ObterTarefasDoProgramador(string username)
        {
            using (var context = new iTaskcontext())
            {
                var prog = context.Programadores.FirstOrDefault(p => p.Username == username);
                if (prog == null)
                    return new List<Tarefa>();

                return context.Tarefas
                    .Where(t => t.ProgramadorId == prog.Id)
                    .OrderBy(t => t.OrdemExecucao)
                    .ToList();
            }
        }

        public List<Tarefa> ObterTarefasDoGestor(string username)
        {
            using (var context = new iTaskcontext())
            {
                var gestor = context.Gestores.FirstOrDefault(g => g.Username == username);
                if (gestor == null)
                    return new List<Tarefa>();

                return context.Tarefas
                    .Where(t => t.GestorId == gestor.Id)
                    .Include("Programador")
                    .OrderBy(t => t.OrdemExecucao)
                    .ToList();
            }
        }

        public bool MudarEstadoParaDoing(int tarefaId, string username, out string mensagemErro)
        {
            using (var context = new iTaskcontext())
            {
                var tarefa = context.Tarefas.Include("Programador").FirstOrDefault(t => t.Id == tarefaId);
                if (tarefa == null)
                {
                    mensagemErro = "Tarefa não encontrada.";
                    return false;
                }

                // Verifica se o utilizador atual é o programador responsável pela tarefa
                if (tarefa.Programador == null || tarefa.Programador.Username != username)
                {
                    mensagemErro = "Apenas o programador responsável pode mover esta tarefa.";
                    return false;
                }

                // Verifica a ordem de execução (deve ser a primeira tarefa do programador em ToDo)
                var proximaTarefa = context.Tarefas
                    .Where(t => t.ProgramadorId == tarefa.ProgramadorId && t.EstadoAtual == EstadoAtual.ToDo)
                    .OrderBy(t => t.OrdemExecucao)
                    .FirstOrDefault();

                if (proximaTarefa == null)
                {
                    mensagemErro = "Não existem tarefas pendentes para este programador.";
                    return false;
                }

                if (proximaTarefa.Id != tarefa.Id)
                {
                    mensagemErro = "Deve executar as tarefas pela ordem definida pelo gestor.";
                    return false;
                }

                // Verifica o limite de tarefas Doing
                int doingCount = context.Tarefas.Count(t => t.ProgramadorId == tarefa.ProgramadorId && t.EstadoAtual == EstadoAtual.Doing);
                if (doingCount >= 2)
                {
                    mensagemErro = "Este programador já tem 2 tarefas em execução.";
                    return false;
                }

                // Atualiza estado
                tarefa.EstadoAtual = EstadoAtual.Doing;
                if (tarefa.DataRealInicio == null)
                    tarefa.DataRealInicio = DateTime.Now;

                context.SaveChanges();
                mensagemErro = null;
                return true;
            }
        }

        public bool MudarEstadoParaToDo(int tarefaId, string username, out string mensagemErro)
        {
            using (var context = new iTaskcontext())
            {
                var tarefa = context.Tarefas
                  .Include("Programador")
                  .FirstOrDefault(t => t.Id == tarefaId);
                if (tarefa == null)
                {
                    mensagemErro = "Tarefa não encontrada.";
                    return false;
                }
                if (tarefa.Programador == null || tarefa.Programador.Username != username)
                {
                    mensagemErro = "Apenas o programador responsável pode mover esta tarefa.";
                    return false;
                }

                tarefa.EstadoAtual = EstadoAtual.ToDo;
                context.SaveChanges();
                mensagemErro = null;
                return true;
            }
        }

        public bool MudarEstadoParaDone(int tarefaId, string username, out string mensagemErro)
        {
            using (var context = new iTaskcontext())
            {
                var tarefa = context.Tarefas
                    .Include("Programador")
                    .FirstOrDefault(t => t.Id == tarefaId);

                if (tarefa == null)
                {
                    mensagemErro = "Tarefa não encontrada.";
                    return false;
                }

                // Confirma se a tarefa pertence ao utilizador
                if (tarefa.Programador == null || tarefa.Programador.Username != username)
                {
                    mensagemErro = "Apenas o programador responsável pode mover esta tarefa.";
                    return false;
                }

                // Confirma se é a próxima tarefa na ordem
                var tarefasDoing = context.Tarefas
                    .Where(t => t.ProgramadorId == tarefa.ProgramadorId && t.EstadoAtual == EstadoAtual.Doing)
                    .OrderBy(t => t.OrdemExecucao)
                    .ToList();

                var proximaDoing = tarefasDoing.FirstOrDefault();

                if (proximaDoing == null || proximaDoing.Id != tarefa.Id)
                {
                    mensagemErro = "Só pode concluir a tarefa que está primeiro na sua lista.";
                    return false;
                }

                tarefa.EstadoAtual = EstadoAtual.Done;
                if (tarefa.DataRealFim == null)
                    tarefa.DataRealFim = DateTime.Now;
                tarefa.OrdemExecucao = 0;


                context.SaveChanges();
                mensagemErro = null;
                return true;
            }
        }

        public bool ExportarTarefasConcluidasParaCSV(string usernameGestor, string caminhoCompleto)
        {
            try
            {
                using (var context = new iTaskcontext())
                {
                    var tarefas = context.Tarefas
                        .Include("Programador")
                        .Include("TipoTarefa")
                        .Include("Gestor")
                        .Where(t => t.EstadoAtual == EstadoAtual.Done && t.Gestor.Username == usernameGestor)
                        .ToList();

                    using (FileStream fs = new FileStream(caminhoCompleto, FileMode.Create, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("Programador;Descricao;DataPrevistaInicio;DataPrevistaFim;TipoTarefa;DataRealInicio;DataRealFim");

                        foreach (var t in tarefas)
                        {
                            string linha = $"{t.Programador?.Username};{t.Descricao};" +
                                           $"{t.DataPrevistaInicio:yyyy-MM-dd};{t.DataPrevistaFim:yyyy-MM-dd};" +
                                           $"{t.TipoTarefa?.Nome};{t.DataRealInicio:yyyy-MM-dd};{t.DataRealFim:yyyy-MM-dd}";
                            sw.WriteLine(linha);
                        }
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
        

