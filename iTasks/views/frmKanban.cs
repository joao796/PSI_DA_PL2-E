﻿using iTasks.Controller;
using iTasks.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            label1.Text = "Bem vindo: " + frmLogin.SessaoUtilizador.Username;
        }

        private void frmKanban_Load(object sender, EventArgs e)
        {
            CarregarTarefasKanban();
            if (controller.PodeCriarTarefa(frmLogin.SessaoUtilizador.Username))
            {
                btNova.Visible = true;
                tarefasEmCursoToolStripMenuItem.Visible = true;
                btnDetalhes.Visible = false;
                exportarParaCSVToolStripMenuItem.Visible = true;
                btPrevisao.Visible = true;
            }
            if (controller.PodeGerirUtilizadores(frmLogin.SessaoUtilizador.Username))
            {
                utilizadoresToolStripMenuItem.Visible = true;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gerirUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controller.PodeGerirUtilizadores(frmLogin.SessaoUtilizador.Username))
            {
                frmGereUtilizadores formGereUtilizadores = new frmGereUtilizadores();
                formGereUtilizadores.Show();
            }
            else
            {

           

            }
        }

        private void gerirTiposDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controller.PodeCriarTarefa(frmLogin.SessaoUtilizador.Username))
            {
                frmGereTiposTarefas formGereTiposTarefas = new frmGereTiposTarefas();
                formGereTiposTarefas.Show();
            }
            else
            {
                
               
            }
        }

        private void CarregarTarefasKanban()
        {
            lstTodo.Items.Clear();
            lstDoing.Items.Clear();
            lstDone.Items.Clear();

            string username = frmLogin.SessaoUtilizador.Username;
            List<Tarefa> tarefas;
      

            using (var db = new iTaskcontext())
            {
                tarefas = db.Tarefas
             .Include("Programador")
             .Include("Gestor")
             .OrderBy(t => t.OrdemExecucao)
             .ToList();
            }

            var tarefasOrdenadas = tarefas.OrderBy(t => t.OrdemExecucao).ToList();

            foreach (var t in tarefas)
            {
                string texto = t.ToStringPara(frmLogin.SessaoUtilizador.Username);
                var item = new TarefaListBoxItem(t, texto);

                switch (t.EstadoAtual)
                {
                    case EstadoAtual.ToDo:
                        lstTodo.Items.Add(item);
                        break;
                    case EstadoAtual.Doing:
                        lstDoing.Items.Add(item);
                        break;
                    case EstadoAtual.Done:
                        lstDone.Items.Add(item);
                        break;
                }
            }
            int totalTarefasToDo = lstTodo.Items.Count;
            int totalTarefasDoing = lstDoing.Items.Count;
            int totalTarefasDone = lstDone.Items.Count;
            label2.Text = $"Tarefas ToDo: {totalTarefasToDo}";
            label3.Text = $"Tarefas Doing: {totalTarefasDoing}";
            label4.Text = $"Tarefas Done: {totalTarefasDone}";            
        }

        public class TarefaListBoxItem
        {
            public Tarefa Tarefa { get; set; }
            public string Texto { get; set; }

            public TarefaListBoxItem(Tarefa tarefa, string texto)
            {
                Tarefa = tarefa;
                Texto = texto;
            }

            public override string ToString()
            {
                return Texto;
            }
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            if (controller.PodeCriarTarefa(frmLogin.SessaoUtilizador.Username))
            {
                using (var db = new iTaskcontext())
                {
                    // passa o gestor logado a partir do username
                    var gestor = db.Gestores.FirstOrDefault(g => g.Username == frmLogin.SessaoUtilizador.Username);
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
           
            }
        }

        private void lstTarefa_DoubleClick(object sender, EventArgs e)
        {
            ListBox lista = sender as ListBox;
            if (lista == null || lista.SelectedItem == null)
                return;

            TarefaListBoxItem item = lista.SelectedItem as TarefaListBoxItem;
            if (item == null)
                return;

            Tarefa tarefaSelecionada = item.Tarefa;

            using (var db = new iTaskcontext())
            {
                var gestor = db.Gestores.FirstOrDefault(g => g.Username == frmLogin.SessaoUtilizador.Username);
                if (gestor == null)
                {
                    MessageBox.Show("Apenas gestores podem editar tarefas.");
                    return;
                }

                var form = new frmDetalhesTarefa();
                form.gestorLogado = gestor;
                form.tarefaAtual = db.Tarefas
                    .Include("Programador")
                    .Include("TipoTarefa")
                    .FirstOrDefault(t => t.Id == tarefaSelecionada.Id);

                form.ShowDialog();
                CarregarTarefasKanban();
            }
        }

        private void btSetDoing_Click(object sender, EventArgs e)
        {
            if (lstTodo.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecione uma tarefa da lista 'ToDo'.");
                return;
            }

            if (!controller.EhProgramador(frmLogin.SessaoUtilizador.Username))
            {
                MessageBox.Show("Apenas programadores podem mover tarefas.");
                return;
            }

            var itemSelecionado = (TarefaListBoxItem)lstTodo.SelectedItem;
            var tarefaSelecionada = itemSelecionado.Tarefa;

            string mensagem;
            bool sucesso = controller.MudarEstadoParaDoing(tarefaSelecionada.Id, frmLogin.SessaoUtilizador.Username, out mensagem);

            if (sucesso)
            {
                CarregarTarefasKanban();
            }
            else
            {
                MessageBox.Show(mensagem ?? "Não foi possível mover a tarefa para 'Doing'.");
            }
        }

        private void btSetTodo_Click(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecione uma tarefa da lista 'Doing'.");
                return;
            }

            if (!controller.EhProgramador(frmLogin.SessaoUtilizador.Username))
            {
                MessageBox.Show("Apenas programadores podem mover tarefas.");
                return;
            }
            var itemSelecionado = (TarefaListBoxItem)lstDoing.SelectedItem;
            var tarefaSelecionada = itemSelecionado.Tarefa;

            string mensagem;
            bool sucesso = controller.MudarEstadoParaToDo(tarefaSelecionada.Id, frmLogin.SessaoUtilizador.Username, out mensagem);

            if (sucesso)
            {
                CarregarTarefasKanban();
            }
            else
            {
                MessageBox.Show(mensagem ?? "Não foi possível mover a tarefa para 'ToDo'.");
            }
        }

        private void btSetDone_Click(object sender, EventArgs e)
        {
            if (lstDoing.SelectedItem == null)
            {
                MessageBox.Show("Por favor selecione uma tarefa da lista 'Doing'.");
                return;
            }

            if (!controller.EhProgramador(frmLogin.SessaoUtilizador.Username))
            {
                MessageBox.Show("Apenas programadores podem mover tarefas.");
                return;
            }

            var itemSelecionado = (TarefaListBoxItem)lstDoing.SelectedItem;
            var tarefaSelecionada = itemSelecionado.Tarefa;

            string mensagem;
            bool sucesso = controller.MudarEstadoParaDone(tarefaSelecionada.Id, frmLogin.SessaoUtilizador.Username, out mensagem);

            if (sucesso)
            {
                CarregarTarefasKanban();
            }
            else
            {
                MessageBox.Show(mensagem ?? "Não foi possível concluir a tarefa. Pode ter tarefas com prioridade mais alta.");
            }
        }


        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            ListBox[] listas = { lstTodo, lstDoing, lstDone };
            TarefaListBoxItem itemSelecionado = null;

            foreach (var lista in listas)
            {
                if (lista.SelectedItem is TarefaListBoxItem item)
                {
                    itemSelecionado = item;
                    break;
                }
            }

            if (itemSelecionado == null)
            {
                MessageBox.Show("Selecione uma tarefa.");
                return;
            }

            using (var db = new iTaskcontext())
            {
                var tarefa = db.Tarefas
                    .Include("Programador")
                    .Include("TipoTarefa")
                    .FirstOrDefault(t => t.Id == itemSelecionado.Tarefa.Id);

                if (tarefa == null)
                {
                    MessageBox.Show("Tarefa não encontrada.");
                    return;
                }

                var form = new frmDetalhesTarefa();
                form.tarefaAtual = tarefa;
                form.SetReadOnlyMode(true);
                form.ShowDialog();
            }
        }


        private void tarefasTerminadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarTarefasConcluidas tarefasConcluidas = new frmConsultarTarefasConcluidas();
            tarefasConcluidas.ShowDialog();
        }

        private void exportarParaCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Ficheiros CSV (*.csv)|*.csv";
                saveDialog.Title = "Guardar Tarefas Concluídas";
                saveDialog.FileName = $"tarefas_concluidas_{frmLogin.SessaoUtilizador.Username}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    var controller = new KanbanController();
                    string usernameGestor = frmLogin.SessaoUtilizador.Username;

                    bool sucesso = controller.ExportarTarefasConcluidasParaCSV(usernameGestor, saveDialog.FileName);

                    if (sucesso)
                        MessageBox.Show("Tarefas exportadas com sucesso!");
                    else
                        MessageBox.Show("Erro ao exportar as tarefas.");
                }
            }
        }


        private void tarefasEmCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaTarefasEmCurso form = new frmConsultaTarefasEmCurso();
            form.ShowDialog();
        }

        private void btPrevisao_Click(object sender, EventArgs e)
        {
            var itemSelecionado = (TarefaListBoxItem)lstTodo.SelectedItem; // ou da lista que usar
            if (itemSelecionado == null)
            {
                lbl_Previsao.Text = "Selecione uma tarefa.";
                lbl_Previsao.Visible = true;
                return;
            }

            double estimativa = controller.ObterEstimativaTempoTarefa(itemSelecionado.Tarefa.Id);
            lbl_Previsao.Text = $"Tempo estimado: {estimativa:F1} horas";
            lbl_Previsao.Visible = true;
        }
    }
}
