namespace iTasks
{
    partial class frmKanban
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstTodo = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstDoing = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstDone = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarParaCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirUtilizadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerirTiposDeTarefasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listagensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarefasTerminadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarefasEmCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tarefaDoGestorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btSetDoing = new System.Windows.Forms.Button();
            this.btSetDone = new System.Windows.Forms.Button();
            this.btSetTodo = new System.Windows.Forms.Button();
            this.btNova = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btPrevisao = new System.Windows.Forms.Button();
            this.btnDetalhes = new System.Windows.Forms.Button();
            this.lbl_Previsao = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTodo
            // 
            this.lstTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTodo.FormattingEnabled = true;
            this.lstTodo.Location = new System.Drawing.Point(3, 16);
            this.lstTodo.Name = "lstTodo";
            this.lstTodo.Size = new System.Drawing.Size(296, 399);
            this.lstTodo.TabIndex = 0;
            this.lstTodo.SelectedIndexChanged += new System.EventHandler(this.lstTodo_SelectedIndexChanged);
            this.lstTodo.DoubleClick += new System.EventHandler(this.lstTarefa_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTodo);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 418);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ToDo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstDoing);
            this.groupBox2.Location = new System.Drawing.Point(320, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 418);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doing";
            // 
            // lstDoing
            // 
            this.lstDoing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDoing.FormattingEnabled = true;
            this.lstDoing.Location = new System.Drawing.Point(3, 16);
            this.lstDoing.Name = "lstDoing";
            this.lstDoing.Size = new System.Drawing.Size(296, 399);
            this.lstDoing.TabIndex = 0;
            this.lstDoing.DoubleClick += new System.EventHandler(this.lstTarefa_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstDone);
            this.groupBox3.Location = new System.Drawing.Point(628, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 418);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Done";
            // 
            // lstDone
            // 
            this.lstDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDone.FormattingEnabled = true;
            this.lstDone.Location = new System.Drawing.Point(3, 16);
            this.lstDone.Name = "lstDone";
            this.lstDone.Size = new System.Drawing.Size(296, 399);
            this.lstDone.TabIndex = 0;
            this.lstDone.DoubleClick += new System.EventHandler(this.lstTarefa_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem,
            this.utilizadoresToolStripMenuItem,
            this.listagensToolStripMenuItem,
            this.tarefaDoGestorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(943, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem,
            this.exportarParaCSVToolStripMenuItem});
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.ficheiroToolStripMenuItem.Text = "Ficheiro";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // exportarParaCSVToolStripMenuItem
            // 
            this.exportarParaCSVToolStripMenuItem.Name = "exportarParaCSVToolStripMenuItem";
            this.exportarParaCSVToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.exportarParaCSVToolStripMenuItem.Text = "Exportar Tarefas Concluídas para CSV";
            this.exportarParaCSVToolStripMenuItem.Visible = false;
            this.exportarParaCSVToolStripMenuItem.Click += new System.EventHandler(this.exportarParaCSVToolStripMenuItem_Click);
            // 
            // utilizadoresToolStripMenuItem
            // 
            this.utilizadoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerirUtilizadoresToolStripMenuItem,
            this.gerirTiposDeTarefasToolStripMenuItem});
            this.utilizadoresToolStripMenuItem.Name = "utilizadoresToolStripMenuItem";
            this.utilizadoresToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.utilizadoresToolStripMenuItem.Text = "Gestão da Aplicação";
            this.utilizadoresToolStripMenuItem.Visible = false;
            // 
            // gerirUtilizadoresToolStripMenuItem
            // 
            this.gerirUtilizadoresToolStripMenuItem.Name = "gerirUtilizadoresToolStripMenuItem";
            this.gerirUtilizadoresToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.gerirUtilizadoresToolStripMenuItem.Text = "Gerir Utilizadores";
            this.gerirUtilizadoresToolStripMenuItem.Click += new System.EventHandler(this.gerirUtilizadoresToolStripMenuItem_Click);
            // 
            // gerirTiposDeTarefasToolStripMenuItem
            // 
            this.gerirTiposDeTarefasToolStripMenuItem.Name = "gerirTiposDeTarefasToolStripMenuItem";
            this.gerirTiposDeTarefasToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.gerirTiposDeTarefasToolStripMenuItem.Text = "Gerir Tipos de Tarefas";
            this.gerirTiposDeTarefasToolStripMenuItem.Click += new System.EventHandler(this.gerirTiposDeTarefasToolStripMenuItem_Click);
            // 
            // listagensToolStripMenuItem
            // 
            this.listagensToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tarefasTerminadasToolStripMenuItem,
            this.tarefasEmCursoToolStripMenuItem});
            this.listagensToolStripMenuItem.Name = "listagensToolStripMenuItem";
            this.listagensToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.listagensToolStripMenuItem.Text = "Listagens";
            // 
            // tarefasTerminadasToolStripMenuItem
            // 
            this.tarefasTerminadasToolStripMenuItem.Name = "tarefasTerminadasToolStripMenuItem";
            this.tarefasTerminadasToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.tarefasTerminadasToolStripMenuItem.Text = "Tarefas Concluídas";
            this.tarefasTerminadasToolStripMenuItem.Click += new System.EventHandler(this.tarefasTerminadasToolStripMenuItem_Click);
            // 
            // tarefasEmCursoToolStripMenuItem
            // 
            this.tarefasEmCursoToolStripMenuItem.Name = "tarefasEmCursoToolStripMenuItem";
            this.tarefasEmCursoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.tarefasEmCursoToolStripMenuItem.Text = "Tarefas em Curso";
            this.tarefasEmCursoToolStripMenuItem.Visible = false;
            this.tarefasEmCursoToolStripMenuItem.Click += new System.EventHandler(this.tarefasEmCursoToolStripMenuItem_Click);
            // 
            // tarefaDoGestorToolStripMenuItem
            // 
            this.tarefaDoGestorToolStripMenuItem.Name = "tarefaDoGestorToolStripMenuItem";
            this.tarefaDoGestorToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.tarefaDoGestorToolStripMenuItem.Text = "Tarefa do Gestor";
            this.tarefaDoGestorToolStripMenuItem.Click += new System.EventHandler(this.tarefaDoGestorToolStripMenuItem_Click);
            // 
            // btSetDoing
            // 
            this.btSetDoing.Location = new System.Drawing.Point(320, 502);
            this.btSetDoing.Name = "btSetDoing";
            this.btSetDoing.Size = new System.Drawing.Size(146, 23);
            this.btSetDoing.TabIndex = 5;
            this.btSetDoing.Text = "Executar Tarefa >>";
            this.btSetDoing.UseVisualStyleBackColor = true;
            this.btSetDoing.Click += new System.EventHandler(this.btSetDoing_Click);
            // 
            // btSetDone
            // 
            this.btSetDone.Location = new System.Drawing.Point(628, 502);
            this.btSetDone.Name = "btSetDone";
            this.btSetDone.Size = new System.Drawing.Size(144, 23);
            this.btSetDone.TabIndex = 6;
            this.btSetDone.Text = "Terminar Tarefa >>";
            this.btSetDone.UseVisualStyleBackColor = true;
            this.btSetDone.Click += new System.EventHandler(this.btSetDone_Click);
            // 
            // btSetTodo
            // 
            this.btSetTodo.Location = new System.Drawing.Point(475, 502);
            this.btSetTodo.Name = "btSetTodo";
            this.btSetTodo.Size = new System.Drawing.Size(144, 23);
            this.btSetTodo.TabIndex = 7;
            this.btSetTodo.Text = "<< Reiniciar Tarefa";
            this.btSetTodo.UseVisualStyleBackColor = true;
            this.btSetTodo.Click += new System.EventHandler(this.btSetTodo_Click);
            // 
            // btNova
            // 
            this.btNova.Location = new System.Drawing.Point(15, 502);
            this.btNova.Name = "btNova";
            this.btNova.Size = new System.Drawing.Size(104, 23);
            this.btNova.TabIndex = 8;
            this.btNova.Text = "Nova Tarefa";
            this.btNova.UseVisualStyleBackColor = true;
            this.btNova.Visible = false;
            this.btNova.Click += new System.EventHandler(this.btNova_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(778, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bem vindo: <Nome Utilizador>";
            // 
            // btPrevisao
            // 
            this.btPrevisao.Location = new System.Drawing.Point(12, 29);
            this.btPrevisao.Name = "btPrevisao";
            this.btPrevisao.Size = new System.Drawing.Size(167, 23);
            this.btPrevisao.TabIndex = 10;
            this.btPrevisao.Text = "Ver Previsão de Conclusão";
            this.btPrevisao.UseVisualStyleBackColor = true;
            this.btPrevisao.Click += new System.EventHandler(this.btPrevisao_Click);
            // 
            // btnDetalhes
            // 
            this.btnDetalhes.Location = new System.Drawing.Point(165, 502);
            this.btnDetalhes.Name = "btnDetalhes";
            this.btnDetalhes.Size = new System.Drawing.Size(104, 23);
            this.btnDetalhes.TabIndex = 11;
            this.btnDetalhes.Text = "Detalhes tarefa";
            this.btnDetalhes.UseVisualStyleBackColor = true;
            this.btnDetalhes.Click += new System.EventHandler(this.btnDetalhes_Click);
            // 
            // lbl_Previsao
            // 
            this.lbl_Previsao.AutoSize = true;
            this.lbl_Previsao.Location = new System.Drawing.Point(185, 34);
            this.lbl_Previsao.Name = "lbl_Previsao";
            this.lbl_Previsao.Size = new System.Drawing.Size(111, 13);
            this.lbl_Previsao.TabIndex = 12;
            this.lbl_Previsao.Text = "Tempo estimado total:";
            this.lbl_Previsao.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Numero tarefas no ToDo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Numero tarefas no Doing:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(626, 479);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Numero tarefas no Done:";
            // 
            // frmKanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 537);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Previsao);
            this.Controls.Add(this.btnDetalhes);
            this.Controls.Add(this.btPrevisao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btNova);
            this.Controls.Add(this.btSetTodo);
            this.Controls.Add(this.btSetDone);
            this.Controls.Add(this.btSetDoing);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmKanban";
            this.Text = "frmKanban";
            this.Load += new System.EventHandler(this.frmKanban_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTodo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstDoing;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstDone;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirUtilizadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerirTiposDeTarefasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarParaCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listagensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarefasTerminadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tarefasEmCursoToolStripMenuItem;
        private System.Windows.Forms.Button btSetDoing;
        private System.Windows.Forms.Button btSetDone;
        private System.Windows.Forms.Button btSetTodo;
        private System.Windows.Forms.Button btNova;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPrevisao;
        private System.Windows.Forms.Button btnDetalhes;
        private System.Windows.Forms.Label lbl_Previsao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem tarefaDoGestorToolStripMenuItem;
    }
}