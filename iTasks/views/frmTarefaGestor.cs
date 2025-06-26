using iTasks.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTasks.Controller;
using iTasks.models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static iTasks.frmKanban;

namespace iTasks.views
{
    public partial class frmTarefaGestor : Form
    {

        private readonly TarefaGestorController controller = new TarefaGestorController();
        public Gestor gestorLogado { get; set; }

        public frmTarefaGestor()
        {
            InitializeComponent();
            AtualizarLista();
            LimparCampos();

        }
        private void LimparCampos()
        {
            txtDesc.Text = "";
        }

        private void AtualizarLista()
        {
            lstTarefas.DataSource = null;
            lstTarefas.DataSource = controller.ObterPorId();

            string username = frmLogin.SessaoUtilizador.Username;
            List<TarefaGestor> tarefagestores;
            lstTarefas.DisplayMember = "Descricao";

                using (var db = new iTaskcontext())
            {
                tarefagestores = db.TarefaGestores
             .Include("Gestor")
             .OrderBy(t => t.Id)
             .ToList();
            }

            var tarefasOrdenadas = tarefagestores.OrderBy(t => t.Id).ToList();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("A descrição não pode estar vazia.");
                return;
            }

            var tarefa = new TarefaGestor
            {
                Descricao = txtDesc.Text.Trim()
            };

            controller.Gravar(tarefa);
  
        }

        private void btSetDone_Click(object sender, EventArgs e)
        {
            if (lstTarefas.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecione uma tarefa");
                return;
            }


            var itemSelecionado = (TarefaListBoxItem)lstTarefas.SelectedItem;
            var tarefaSelecionada = itemSelecionado.Tarefa;

            string mensagem;
            bool sucesso = controller.MudarEstadoParaTerminado(tarefaSelecionada.Id, frmLogin.SessaoUtilizador.Username, out mensagem);

            if (sucesso)
            {
                AtualizarLista();
            }
            else
            {
                MessageBox.Show(mensagem ?? "Não foi possível concluir a tarefa.");
            }
        }
    }
}
