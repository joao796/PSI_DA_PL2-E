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


namespace iTasks
{
    public partial class frmConsultaTarefasEmCurso : Form
    {
        public frmConsultaTarefasEmCurso()
        {
            InitializeComponent();
            CarregarTarefasEmCurso();
        }

        private void CarregarTarefasEmCurso()
        {
            using (var db = new iTaskcontext())
            {
                var tarefasDoing = db.Tarefas
                    .Where(t => t.EstadoAtual == EstadoAtual.Doing)
                    .Select(t => new
                    {
                        t.Id,
                        t.Descricao,
                        Programador = t.Programador.Nome,
                        Tipo = t.TipoTarefa.Nome,
                        t.OrdemExecucao,
                        t.DataPrevistaInicio,
                        t.DataPrevistaFim
                    })
                    .ToList();

                gvTarefasEmCurso.DataSource = tarefasDoing;
            }
        }
        private void gvTarefasEmCurso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}