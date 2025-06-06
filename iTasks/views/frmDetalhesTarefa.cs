using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.models;
using iTasks.Controller;

namespace iTasks
{
    public partial class frmDetalhesTarefa : Form
    {
        private readonly TarefaController controller = new TarefaController();

        public Gestor gestorLogado { get; set; }
        public Tarefa tarefaAtual { get; set; }
  


        public frmDetalhesTarefa()
        {
            InitializeComponent();
            this.Load += frmDetalhesTarefa_Load;

         
        }

        private void frmDetalhesTarefa_Load(object sender, EventArgs e)
        {
         

            

            // Carregar no combobox os tipos de tarefa
            cbTipoTarefa.DataSource = controller.ObterTiposTarefa();
            cbTipoTarefa.DisplayMember = "Nome";
            cbTipoTarefa.ValueMember = "Id";

            // Carregar no combobox os programadores associados ao gestor
            cbProgramador.DataSource = controller.ObterProgramadoresDoGestor(gestorLogado.Id);
            cbProgramador.DisplayMember = "Nome";
            cbProgramador.ValueMember = "Id";

            if (tarefaAtual != null)
            {
                // Edição
                txtId.Text = tarefaAtual.Id.ToString();
                txtDesc.Text = tarefaAtual.Descricao;
                txtOrdem.Text = tarefaAtual.OrdemExecucao.ToString();
                txtStoryPoints.Text = tarefaAtual.StoryPoints.ToString();
                cbProgramador.SelectedValue = tarefaAtual.ProgramadorId;
                cbTipoTarefa.SelectedValue = tarefaAtual.TipoTarefaId;
                dtInicio.Value = tarefaAtual.DataPrevistaInicio;
                dtFim.Value = tarefaAtual.DataPrevistaFim;

                txtEstado.Text = tarefaAtual.EstadoAtual.ToString();
                txtDataCriacao.Text = tarefaAtual.DataCriacao.ToShortDateString();
                txtDataRealini.Text = tarefaAtual.DataRealInicio?.ToShortDateString() ?? "";
                txtdataRealFim.Text = tarefaAtual.DataRealFim?.ToShortDateString() ?? "";
            }
            else
            {
                // Nova tarefa
                txtEstado.Text = EstadoAtual.ToDo.ToString();
                txtDataCriacao.Text = DateTime.Now.ToShortDateString();
                txtId.Text = gestorLogado.Id.ToString();
            }
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDesc.Text) || cbProgramador.SelectedItem == null || cbTipoTarefa.SelectedItem == null)
            {
                MessageBox.Show("Preenche todos os campos obrigatórios.");
                return;
            }

            if (!int.TryParse(txtOrdem.Text, out int ordem) || !int.TryParse(txtStoryPoints.Text, out int sp))
            {
                MessageBox.Show("Ordem e StoryPoints devem ser números válidos.");
                return;
            }

            int programadorId = (int)cbProgramador.SelectedValue;
            int? tarefaId = tarefaAtual?.Id;

            if (controller.OrdemRepetida(programadorId, ordem, tarefaId))
            {
                MessageBox.Show("Já existe uma tarefa com essa ordem para este programador.");
                return;
            }

            if (tarefaAtual == null)
                tarefaAtual = new Tarefa();

            tarefaAtual.Descricao = txtDesc.Text.Trim();
            tarefaAtual.OrdemExecucao = ordem;
            tarefaAtual.StoryPoints = sp;
            tarefaAtual.ProgramadorId = programadorId;
            tarefaAtual.TipoTarefaId = (int)cbTipoTarefa.SelectedValue;
            tarefaAtual.DataPrevistaInicio = dtInicio.Value;
            tarefaAtual.DataPrevistaFim = dtFim.Value;
            tarefaAtual.GestorId = gestorLogado.Id;

            if (tarefaId == null)
                controller.GravarNovaTarefa(tarefaAtual);
            else
                controller.AtualizarTarefa(tarefaAtual);

            MessageBox.Show("Tarefa gravada com sucesso.");
            this.Close();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        public void SetReadOnlyMode(bool readOnly)
        {
            txtDesc.ReadOnly = readOnly;
            cbTipoTarefa.Enabled = readOnly;
            cbProgramador.Enabled = !readOnly;
            txtOrdem.ReadOnly = !readOnly;
            txtStoryPoints.ReadOnly = !readOnly;
            dtInicio.Enabled = !readOnly;
            dtFim.Enabled = !readOnly;
            btGravar.Visible = !readOnly; 
        }

    }
}
