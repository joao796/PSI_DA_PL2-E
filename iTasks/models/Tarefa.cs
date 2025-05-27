using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTasks.models;

namespace iTasks.models
{
    public class Tarefa
    {
        public int Id { get; set; }

        // Relações
        public Gestor Gestor { get; set; }
        public Programador Programador { get; set; }
        public TipoTarefa TipoTarefa { get; set; }
        public int TipoTarefaId { get; set; }

        // Dados
        public string Descricao { get; set; }
        public int OrdemExecucao { get; set; }
        public int StoryPoints { get; set; }

        // Datas
        public DateTime DataCriacao { get; set; }
        public DateTime DataPrevistaInicio { get; set; }
        public DateTime DataPrevistaFim { get; set; }

        public DateTime DataRealInicio { get; set; }
        public DateTime DataRealFim { get; set; }

        public EstadoAtual EstadoAtual { get; set; }
    }
    public enum EstadoAtual
    {
       ToDo,
       Doing,
       done
    }
}
