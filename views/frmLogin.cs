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
                frmKanban kanban = new frmKanban(login);
               
                kanban.Show();
            }
            else
            {
                MessageBox.Show("Username ou password incorretos.");
            }
        }
    }
}
