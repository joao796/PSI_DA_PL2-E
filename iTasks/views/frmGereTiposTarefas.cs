using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.Controller;
using iTasks.models;


namespace iTasks
{
    public partial class frmGereTiposTarefas : Form
    {
        private TipoTarefaController controller = new TipoTarefaController();
        private TipoTarefa tipoSelecionado = null;

        public frmGereTiposTarefas()
        {
            InitializeComponent();
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            lstLista.DataSource = null;
            lstLista.DataSource = controller.ObterTodos();
            lstLista.DisplayMember = "Nome";
        }

        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoSelecionado = lstLista.SelectedItem as TipoTarefa;
            if (tipoSelecionado != null)
            {
                txtId.Text = tipoSelecionado.Id.ToString();
                txtDesc.Text = tipoSelecionado.Nome;
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("A descrição não pode estar vazia.");
                return;
            }

            var tipo = new TipoTarefa
            {
                Nome = txtDesc.Text.Trim()
            };

            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                tipo.Id = int.Parse(txtId.Text); // se já existe
            }

            controller.Gravar(tipo);
            AtualizarLista();
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtId.Text = "";
            txtDesc.Text = "";
            tipoSelecionado = null;
        }

        private void btApagar_Click(object sender, EventArgs e)
        {
            if (tipoSelecionado == null)
            {
                MessageBox.Show("Seleciona um tipo de tarefa para apagar.");
                return;
            }

            var confirmar = MessageBox.Show("Tens a certeza que queres apagar este tipo de tarefa?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    controller.Apagar(tipoSelecionado.Id);
                    AtualizarLista();
                    LimparCampos();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Erro ao Apagar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
