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
    public class TarefaController
    {
        private readonly iTaskcontext db = new iTaskcontext();

        public Tarefa ObterPorId(int id)
        {
            return db.Tarefas.FirstOrDefault(t => t.Id == id);
        }

        public void GravarNovaTarefa(Tarefa tarefa)
        {
            tarefa.DataCriacao = DateTime.Now;
            tarefa.EstadoAtual = EstadoAtual.ToDo;
            db.Tarefas.Add(tarefa);
            db.SaveChanges();
        }

        public void AtualizarTarefa(Tarefa tarefa)
        {
            var original = db.Tarefas.FirstOrDefault(t => t.Id == tarefa.Id);
            if (original != null)
            {
                original.Descricao = tarefa.Descricao;
                original.OrdemExecucao = tarefa.OrdemExecucao;
                original.StoryPoints = tarefa.StoryPoints;
                original.ProgramadorId = tarefa.ProgramadorId;
                original.TipoTarefaId = tarefa.TipoTarefaId;
                original.DataPrevistaInicio = tarefa.DataPrevistaInicio;
                original.DataPrevistaFim = tarefa.DataPrevistaFim;
                db.SaveChanges();
            }
        }

        // é para ver se já há alguma tarefa com a mesma ordem (OrdemExecucao) para o mesmo programador
        // int? = Nullable<int> | é para evitar de criar 2 versões do mesmo método
        public bool OrdemRepetida(int programadorId, int ordem, int? tarefaId = null)
        {
            return db.Tarefas.Any(t =>
                t.ProgramadorId == programadorId &&
                t.OrdemExecucao == ordem &&
                (!tarefaId.HasValue || t.Id != tarefaId.Value));
        }

        public List<Programador> ObterProgramadoresDoGestor(int gestorId)
        {
            return db.Programadores
                     .Where(p => p.Gestor.Id == gestorId)
                     .ToList();
        }

        public List<TipoTarefa> ObterTiposTarefa()
        {
            return db.TipoTarefas.ToList();
        }
    }
}
