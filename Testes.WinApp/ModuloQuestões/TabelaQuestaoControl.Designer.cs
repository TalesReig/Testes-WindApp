namespace Testes.WinApp.ModuloQuestões
{
    partial class TabelaQuestaoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabelaQuestoes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaQuestoes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabelaQuestoes
            // 
            this.tabelaQuestoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaQuestoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaQuestoes.Location = new System.Drawing.Point(0, 0);
            this.tabelaQuestoes.Name = "tabelaQuestoes";
            this.tabelaQuestoes.RowTemplate.Height = 25;
            this.tabelaQuestoes.Size = new System.Drawing.Size(809, 393);
            this.tabelaQuestoes.TabIndex = 0;
            // 
            // TabelaQuestaoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabelaQuestoes);
            this.Name = "TabelaQuestaoControl";
            this.Size = new System.Drawing.Size(809, 393);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaQuestoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tabelaQuestoes;
    }
}
