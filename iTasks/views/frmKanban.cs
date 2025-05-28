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
            CarregarTarefasKanban();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controller.PodeGerirUtilizadores(frmLogin.SessaoUsuario.Username))
            {
                frmGereUtilizadores formGereUtilizadores = new frmGereUtilizadores();
                formGereUtilizadores.Show();
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
            }
            else
            {
                MessageBox.Show("Não tem permissões entrar aqui");
            }
        }

        private void CarregarTarefasKanban()
        {
            lstTodo.Items.Clear();
            lstDoing.Items.Clear();
            lstDone.Items.Clear();

            string username = frmLogin.SessaoUsuario.Username;
            List<Tarefa> tarefas;

            using (var db = new iTaskcontext())
            {
                var utilizador = db.Utilizadores.FirstOrDefault(u => u.Username == username);

                if (utilizador is Programador)
                {
                    tarefas = controller.ObterTarefasDoProgramador(username);
                }
                else if (utilizador is Gestor)
                {
                    tarefas = controller.ObterTarefasDoGestor(username);
                }
                else
                {
                    tarefas = new List<Tarefa>();
                }
            }

            foreach (var t in tarefas)
            {
                string texto = t.ToStringPara(frmLogin.SessaoUsuario.Username);

                switch (t.EstadoAtual)
                {
                    case EstadoAtual.ToDo:
                        lstTodo.Items.Add(texto);
                        break;
                    case EstadoAtual.Doing:
                        lstDoing.Items.Add(texto);
                        break;
                    case EstadoAtual.Done:
                        lstDone.Items.Add(texto);
                        break;
                }
            }
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            if (controller.PodeCriarTarefa(frmLogin.SessaoUsuario.Username))
            {
                using (var db = new iTaskcontext())
                {
                    // passa o gestor logado a partir do username
                    var gestor = db.Gestores.FirstOrDefault(g => g.Username == frmLogin.SessaoUsuario.Username);
                    if (gestor != null)
                    {
                        frmDetalhesTarefa formDetalhesTarefa = new frmDetalhesTarefa();
                        formDetalhesTarefa.gestorLogado = gestor;
                        formDetalhesTarefa.ShowDialog();
                        CarregarTarefasKanban();
                    }
                    else
                    {
                        MessageBox.Show("Erro: gestor não encontrado.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Não tem permissões para criar tarefas.");
            }
        }
    }
}
