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

namespace iTasks
{
    public partial class frmConsultarTarefasConcluidas : Form
    {
        private KanbanController controller = new KanbanController();
        public frmConsultarTarefasConcluidas()
        {
            InitializeComponent();

            gvTarefasConcluidas.Columns.Add("Tipo", "Tipo");
            
            if (controller.PodeCriarTarefa(frmLogin.SessaoUtilizador.Username))
            {
                gvTarefasConcluidas.Rows.Add("gestor");
            }
            else
            {
                gvTarefasConcluidas.Rows.Add("programador");
            }
          
        }

        private void frmConsultarTarefasConcluidas_Load(object sender, EventArgs e)
        {

        }
    }
}
