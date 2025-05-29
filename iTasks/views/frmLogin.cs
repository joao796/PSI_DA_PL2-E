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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public static class SessaoUtilizador
        {
            public static string Username { get; set; }
        }
        private void btLogin_Click(object sender, EventArgs e)
        {

            var login = new Utilizador
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };
            var controller = new LoginController();
           if (controller.Login(login))
            {
                SessaoUtilizador.Username = login.Username;
                frmKanban kanban = new frmKanban(login);

                this.Hide();
                kanban.ShowDialog();
                    this.Show();
                    txtUsername.Clear();
                    txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Username ou password incorretos.");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
