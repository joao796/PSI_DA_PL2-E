using iTasks.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace iTasks.Controller
{
    public class TipoTarefaController
    {
        private readonly iTaskcontext db = new iTaskcontext();

        public List<TipoTarefa> ObterTodos()
        {
            return db.TipoTarefas.OrderBy(t => t.Nome).ToList();
        }

        public TipoTarefa ObterPorId(int id)
        {
            return db.TipoTarefas.FirstOrDefault(t => t.Id == id);
        }

        public void Gravar(TipoTarefa tipo)
        {
            if (tipo.Id == 0)
            {
                db.TipoTarefas.Add(tipo);
            }
            else
            {
                var existente = db.TipoTarefas.Find(tipo.Id);
                if (existente != null)
                {
                    existente.Nome = tipo.Nome;
                }
            }

            db.SaveChanges();
        }

        public void Apagar(int id)
        {
            var tipo = db.TipoTarefas.Find(id);
            if (tipo != null)
            {
                // isto é para verificar se o tipo está associado a alguma tarefa criada
                bool usado = db.Tarefas.Any(t => t.TipoTarefaId == id);
                if (usado)
                    throw new InvalidOperationException("Não é possível apagar: este tipo de tarefa está associado a uma ou mais tarefas.");

                db.TipoTarefas.Remove(tipo);
                db.SaveChanges();
            }
        }
    }
}
