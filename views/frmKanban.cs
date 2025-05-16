using iTasks.Controller;
using iTasks.models;
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
    public partial class frmKanban : Form
    {
        private KanbanController controller = new KanbanController();
        private string username;
        public frmKanban(Utilizador utilizador)
        { 
           InitializeComponent();
            this.username = username;

        }
        private void frmKanban_Load(object sender, EventArgs e)
        {

            label1.Text = $"Bem-vindo, {nome ?? "utilizador"}!";

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGereUtilizadores formGereUtilizadores = new frmGereUtilizadores();

          
            formGereUtilizadores.Show();
        }

        private void frmKanban_Load_1(object sender, EventArgs e)
        {

        }
    }
}
