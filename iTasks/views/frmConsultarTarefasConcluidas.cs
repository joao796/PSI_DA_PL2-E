using iTasks.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace iTasks
{
    public partial class frmConsultarTarefasConcluidas : Form
    {
        private KanbanController controller = new KanbanController();
        private TarefasConcluidasController controller2 = new TarefasConcluidasController();
        public frmConsultarTarefasConcluidas()
        {
            InitializeComponent();

            
            if (controller.PodeCriarTarefa(frmLogin.SessaoUtilizador.Username))
            {
                gvTarefasConcluidas.Rows.Clear();
                gvTarefasConcluidas.Columns.Clear();

                gvTarefasConcluidas.Columns.Add("id", "ID da tarefa");
                gvTarefasConcluidas.Columns.Add("descricao", "Descrição");
                gvTarefasConcluidas.Columns.Add("dias", "Dias");
                gvTarefasConcluidas.Columns.Add("diasprevisto", "Dias previstos");
                gvTarefasConcluidas.Columns.Add("programador", "Programador");


                var tarefas = controller2.ObterTarefasConcluidasDoGestor(frmLogin.SessaoUtilizador.Username);

                foreach (var t in tarefas)
                {
                    int dias = (t.DataRealFim.Value - t.DataRealInicio.Value).Days;
                    int previsao = (t.DataPrevistaFim - t.DataPrevistaInicio).Days;
                    gvTarefasConcluidas.Rows.Add(t.Id, t.Descricao, dias+1, previsao+1, t.Programador.Username);
                }
            }
            else
            {
                gvTarefasConcluidas.Rows.Clear();
                gvTarefasConcluidas.Columns.Clear();

                gvTarefasConcluidas.Columns.Add("id", "ID da tarefa");
                gvTarefasConcluidas.Columns.Add("descricao", "Descrição");
                gvTarefasConcluidas.Columns.Add("dias", "Dias");

                var tarefas = controller2.ObterTarefasConcluidasDoProgramador(frmLogin.SessaoUtilizador.Username);

                foreach (var t in tarefas)
                {
                    int dias = (t.DataRealFim.Value - t.DataRealInicio.Value).Days;
                    gvTarefasConcluidas.Rows.Add(t.Id, t.Descricao, dias+1);
                }
            }

        }

        private void frmConsultarTarefasConcluidas_Load(object sender, EventArgs e)
        {

        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
