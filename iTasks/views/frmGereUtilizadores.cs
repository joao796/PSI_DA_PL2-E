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
            cbDepartamento.DataSource = Enum.GetValues(typeof(Departamento));
            cbNivelProg.DataSource = Enum.GetValues(typeof(NivelExperiencia));
            CarregarGestores();
            AtualizarListaGestores();
            AtualizarListaProgramadores();
            LimparCampos();
        }

        private void btGravarGestor_Click(object sender, EventArgs e)
        {
            var gestor = new Gestor
            {
                Nome = txtNomeGestor.Text,
                Username = txtUsernameGestor.Text,
                Password = txtPasswordGestor.Text,
                Departamento = (Departamento)cbDepartamento.SelectedItem,
                GereUtilizadores = chkGereUtilizadores.Checked
            };

            if (controller.AdicionarGestor(gestor))
            {
                MessageBox.Show("Gestor adicionado com sucesso!");
                AtualizarListaGestores();
                CarregarGestores();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar gestor. Verifique se o username já existe.");
            }
        }

        private void AtualizarListaGestores()
        {
            lstListaGestores.Items.Clear();
            var gestores = controller.ListarGestores();

            foreach (var g in gestores)
            {
                lstListaGestores.Items.Add(g.ToString());
            }
        }

        private void CarregarGestores()
        {
            var gestores = controller.ListarGestores();

            cbGestorProg.DataSource = gestores;
            cbGestorProg.DisplayMember = "Nome";
            cbGestorProg.ValueMember = "Id";
        }

        private void btGravarProg_Click(object sender, EventArgs e)
        {
            var programador = new Programador
            {
                Nome = txtNomeProg.Text,
                Username = txtUsernameProg.Text,
                Password = txtPasswordProg.Text,
                NivelExperiencia = (NivelExperiencia)cbNivelProg.SelectedItem,
                Gestor = new Gestor
                {
                    Id = (int)cbGestorProg.SelectedValue
                }
            };

            if (controller.AdicionarProgramador(programador))
            {
                MessageBox.Show("Programador adicionado com sucesso!");
                AtualizarListaProgramadores();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao adicionar programador. Verifique se o username já existe.");
            }
        }

        private void AtualizarListaProgramadores()
        {
            lstListaProgramadores.Items.Clear();
            var programadores = controller.ListarProgramadores();

            foreach (var p in programadores)
            {
                lstListaProgramadores.Items.Add(p.ToString());
            }
        }

        private void LimparCampos()
        {
            // Gestor
            txtIdGestor.Text = "";
            txtNomeGestor.Text = "";
            txtUsernameGestor.Text = "";
            txtPasswordGestor.Text = "";
            chkGereUtilizadores.Checked = false;
            cbDepartamento.SelectedIndex = -1;

            // Programador
            txtIdProg.Text = "";
            txtNomeProg.Text = "";
            txtUsernameProg.Text = "";
            txtPasswordProg.Text = "";
            cbNivelProg.SelectedIndex = -1;
            cbGestorProg.SelectedIndex = -1;
        }
    }
}

