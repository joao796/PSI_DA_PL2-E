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
    public class TarefaGestorController
    {
        private readonly iTaskcontext db = new iTaskcontext();

        public TarefaGestor ObterPorId(int id)
        {
            return db.TarefaGestores.FirstOrDefault(t => t.Id == id);
        }

        public void Gravar(TarefaGestor tarefagestor)
        {
            db.TarefaGestores.Add(tarefagestor);
            db.SaveChanges();
        }

        public bool MudarEstadoParaTerminado(int Id, string descricao, out string mensagemErro)
        {
            using (var context = new iTaskcontext())
            {
                var tarefagestor = context.Tarefas
                    .Include("Gestor")
                    .FirstOrDefault(t => t.Id == Id);

                if (tarefagestor == null)
                {
                    mensagemErro = "Tarefa não encontrada.";
                    return false;
                }


              

                var terminado = Terminado.FirstOrDefault();

                if (terminado == null || terminado.Id != tarefagestor.Id)
                {
                    mensagemErro = "Só pode concluir a tarefa depois de selecionar na sua lista.";
                    return false;
                }

                tarefagestor.Terminado = terminado.Done;


                context.SaveChanges();
                mensagemErro = null;
                return true;
            }
        }
    }
}
