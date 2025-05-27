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
            if (controller.PodeGerirUtilizadores(frmLogin.SessaoUsuario.Username))
            {
                frmGereUtilizadores formGereUtilizadores = new frmGereUtilizadores();
                formGereUtilizadores.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Não tem permissões entrar aqui");
            }
        }

        private void frmKanban_Load_1(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            if (controller.PodeCriarTarefa(frmLogin.SessaoUsuario.Username))
            {
                frmDetalhesTarefa formDetalhesTarefa = new frmDetalhesTarefa();
                formDetalhesTarefa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Não tem permissões entrar aqui");
            }
        }

        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controller.PodeCriarTarefa(frmLogin.SessaoUsuario.Username))
            {
                frmGereTiposTarefas formGereTiposTarefas = new frmGereTiposTarefas();
                formGereTiposTarefas.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Não tem permissões entrar aqui");
            }
        }
    }
}
