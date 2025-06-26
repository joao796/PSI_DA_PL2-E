namespace iTasks.views
{
    partial class frmTarefaGestor
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lstTarefas = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btGravar = new System.Windows.Forms.Button();
            this.btSetDone = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lstTarefas);
            this.groupBox.Location = new System.Drawing.Point(33, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(302, 418);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Tarefas";
            // 
            // lstTarefas
            // 
            this.lstTarefas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTarefas.FormattingEnabled = true;
            this.lstTarefas.Location = new System.Drawing.Point(3, 16);
            this.lstTarefas.Name = "lstTarefas";
            this.lstTarefas.Size = new System.Drawing.Size(296, 399);
            this.lstTarefas.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Descrição:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(363, 60);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(425, 20);
            this.txtDesc.TabIndex = 12;
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(363, 109);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(141, 23);
            this.btGravar.TabIndex = 29;
            this.btGravar.Text = "Gravar Dados";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // btSetDone
            // 
            this.btSetDone.Location = new System.Drawing.Point(521, 109);
            this.btSetDone.Name = "btSetDone";
            this.btSetDone.Size = new System.Drawing.Size(144, 23);
            this.btSetDone.TabIndex = 30;
            this.btSetDone.Text = "Terminar Tarefa";
            this.btSetDone.UseVisualStyleBackColor = true;
            this.btSetDone.Click += new System.EventHandler(this.btSetDone_Click);
            // 
            // frmTarefaGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btSetDone);
            this.Controls.Add(this.btGravar);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox);
            this.Name = "frmTarefaGestor";
            this.Text = "frmTarefaGestor";
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ListBox lstTarefas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btGravar;
        private System.Windows.Forms.Button btSetDone;
    }
}