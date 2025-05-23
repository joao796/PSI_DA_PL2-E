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

        public frmKanban(Utilizador utilizador)
        { 
           InitializeComponent();
            label1.Text = "Bem vindo: " + frmLogin.SessaoUsuario.Username;

        }
        private void frmKanban_Load(object sender, EventArgs e)
        {

      
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (controller.PodeGerirUtilizadores())
            {
                frmGereUtilizadores formGereUtilizadores = new frmGereUtilizadores();
                formGereUtilizadores.Show();
            }
            else
            {
                MessageBox.Show("Não tem permissões para gerir utilizadores.");
            }
        }

        private void frmKanban_Load_1(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
