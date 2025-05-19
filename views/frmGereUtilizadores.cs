using iTasks.Controller;
using iTasks.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iTasks
{
    public partial class frmGereUtilizadores : Form
    {
        GereUtilizadoresController controller = new GereUtilizadoresController();
        public frmGereUtilizadores()
        {
            InitializeComponent();
            cbDepartamento.Items.AddRange(new string[] { "IT", "Marketing", "Administração" });
            AtualizarListaGestores();
        }

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            var gestor = new Gestor
            {
                Nome = txtNomeGestor.Text,
                Username = txtUsernameGestor.Text,
                Password = txtPasswordGestor.Text,
                Departamento = cbDepartamento.SelectedItem?.ToString(),
                GereUtilizadores = chkGereUtilizadores.Checked
            };

            if (controller.AdicionarGestor(gestor))
            {
                MessageBox.Show("Gestor adicionado com sucesso!");
                AtualizarListaGestores();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar gestor.");
            }
        }

        private void AtualizarListaGestores()
        {
            lstListaGestores.Items.Clear();
            var gestores = controller.ListarGestores();

            foreach (var g in gestores)
            {
                lstListaGestores.Items.Add($"{g.Nome} ({g.Departamento})");
            }
        }
    }
}
