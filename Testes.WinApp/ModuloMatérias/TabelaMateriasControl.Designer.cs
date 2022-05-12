namespace Testes.WinApp.ModuloMatérias
{
    partial class TabelaMateriasControl
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
            this.tabelaMaterias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // tabelaMaterias
            // 
            this.tabelaMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaMaterias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaMaterias.Location = new System.Drawing.Point(0, 0);
            this.tabelaMaterias.Name = "tabelaMaterias";
            this.tabelaMaterias.RowTemplate.Height = 25;
            this.tabelaMaterias.Size = new System.Drawing.Size(486, 348);
            this.tabelaMaterias.TabIndex = 0;
            // 
            // TabelaMateriasControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabelaMaterias);
            this.Name = "TabelaMateriasControl";
            this.Size = new System.Drawing.Size(486, 348);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaMaterias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tabelaMaterias;
    }
}
