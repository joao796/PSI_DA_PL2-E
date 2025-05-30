using iTasks.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public bool MudarEstadoParaDoing(int tarefaId, out string mensagemErro)
        {
            using (var context = new iTaskcontext())
            {
                var tarefa = context.Tarefas.Include("Programador").FirstOrDefault(t => t.Id == tarefaId);
                if (tarefa == null)
                {
                    mensagemErro = "Tarefa não encontrada.";
                    return false;
                }

                // Regra: no máximo 2 tarefas Doing por programador
                int doingCount = context.Tarefas.Count(t => t.ProgramadorId == tarefa.ProgramadorId && t.EstadoAtual == EstadoAtual.Doing);
                if (doingCount >= 2)
                {
                    mensagemErro = "Este programador já tem 2 tarefas em execução.";
                    return false;
                }

                tarefa.EstadoAtual = EstadoAtual.Doing;
                if (tarefa.DataRealInicio == null)
                    tarefa.DataRealInicio = DateTime.Now;

                context.SaveChanges();
                mensagemErro = null;
                return true;
            }
        }

        public bool MudarEstadoParaToDo(int tarefaId, out string mensagemErro)
        {
            using (var context = new iTaskcontext())
            {
                var tarefa = context.Tarefas.FirstOrDefault(t => t.Id == tarefaId);
                if (tarefa == null)
                {
                    mensagemErro = "Tarefa não encontrada.";
                    return false;
                }

                tarefa.EstadoAtual = EstadoAtual.ToDo;
                context.SaveChanges();
                mensagemErro = null;
                return true;
            }
        }

        public bool MudarEstadoParaDone(int tarefaId, out string mensagemErro)
        {
            using (var context = new iTaskcontext())
            {
                var tarefa = context.Tarefas.FirstOrDefault(t => t.Id == tarefaId);
                if (tarefa == null)
                {
                    mensagemErro = "Tarefa não encontrada.";
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
    }
}
