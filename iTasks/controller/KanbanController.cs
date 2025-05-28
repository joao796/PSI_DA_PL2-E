using iTasks.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
