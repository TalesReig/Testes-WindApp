namespace Testes.WinApp.ModuloTeste
{
    partial class TabelaTesteControl
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
            this.tabelaTestes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaTestes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabelaTestes
            // 
            this.tabelaTestes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaTestes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaTestes.Location = new System.Drawing.Point(0, 0);
            this.tabelaTestes.Name = "tabelaTestes";
            this.tabelaTestes.RowTemplate.Height = 25;
            this.tabelaTestes.Size = new System.Drawing.Size(604, 433);
            this.tabelaTestes.TabIndex = 0;
            // 
            // TabelaTesteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabelaTestes);
            this.Name = "TabelaTesteControl";
            this.Size = new System.Drawing.Size(604, 433);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaTestes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tabelaTestes;
    }
}
