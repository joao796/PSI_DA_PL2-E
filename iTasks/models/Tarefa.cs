using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.models;


namespace iTasks.models
{
    public class Tarefa
    {
        public int Id { get; set; }

        // Relações
        public Gestor Gestor { get; set; }
        public int GestorId { get; set; }
        public Programador Programador { get; set; }
        public int ProgramadorId { get; set; }
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

        // ? — isso é necessário porque as datas podem estar em branco, quando a tarefa está em ToDo ou Doing.
        public DateTime? DataRealInicio { get; set; }
        public DateTime? DataRealFim { get; set; }

        public EstadoAtual EstadoAtual { get; set; }


        public override string ToString()
        {

            return $"#{OrdemExecucao} - {Descricao}  {DataPrevistaFim}";
        }
        public string ToStringPara(string username)
        {
            if (Programador != null && Programador.Username != username)
                return $"[⚠] #{OrdemExecucao} - {Descricao} ({Programador.Username}) - {DataPrevistaFim:dd/MM/yyyy}";
            else
                return $"#{OrdemExecucao} - {Descricao}  {DataPrevistaFim}";
        }
        public int CalcularDiasParaConclusao()
        {
            if (EstadoAtual == EstadoAtual.Done && DataRealInicio.HasValue && DataRealFim.HasValue)
            {
                return (DataRealFim.Value - DataRealInicio.Value).Days;
            }
            else
            {
                MessageBox.Show("Não é possível calcular o tempo de conclusão: tarefa incompleta ou datas ausentes.");
                return 0;
            }
        }
    }

    public enum EstadoAtual
    {
       ToDo,
       Doing,
       Done
    }
}
