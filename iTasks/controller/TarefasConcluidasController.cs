using iTasks.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iTasks.Controller
{
    class TarefasConcluidasController
    {
        public bool TipoUtilizador(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            using (var context = new iTaskcontext())
            {
                return context.Gestores.Any(g => g.Username == username);
            }
        }


        public List<Tarefa> ObterTarefasConcluidasDoProgramador(string username)
        {
            using (var context = new iTaskcontext())
            {
                return context.Tarefas
                    .Where(t => t.EstadoAtual == EstadoAtual.Done
                                && t.Programador.Username == username
                                && t.DataRealInicio.HasValue
                                && t.DataRealFim.HasValue)
                    .ToList();
            }
        }

            public List<Tarefa> ObterTarefasConcluidasDoGestor(string username)
            {
                using (var context = new iTaskcontext())
                {
                    return context.Tarefas
                        .Include("Programador")
                        .Where(t => t.EstadoAtual == EstadoAtual.Done
                                    && t.Gestor.Username == username
                                    && t.DataRealInicio.HasValue
                                    && t.DataRealFim.HasValue
                                   )

                        .ToList();
                }
            }

    }
}
