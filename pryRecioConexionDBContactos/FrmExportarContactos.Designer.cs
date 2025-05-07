namespace pryRecioConexionDBContactos
{
    partial class FrmExportarContactos
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnExportarCSV = new System.Windows.Forms.Button();
            this.btnExportarVCard = new System.Windows.Forms.Button();
            this.vOlverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Nirmala Text", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vOlverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnExportarCSV
            // 
            this.btnExportarCSV.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCSV.Location = new System.Drawing.Point(47, 63);
            this.btnExportarCSV.Name = "btnExportarCSV";
            this.btnExportarCSV.Size = new System.Drawing.Size(174, 37);
            this.btnExportarCSV.TabIndex = 1;
            this.btnExportarCSV.Text = "Exportar CSV";
            this.btnExportarCSV.UseVisualStyleBackColor = true;
            this.btnExportarCSV.Click += new System.EventHandler(this.btnExportarCSV_Click);
            // 
            // btnExportarVCard
            // 
            this.btnExportarVCard.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarVCard.Location = new System.Drawing.Point(288, 63);
            this.btnExportarVCard.Name = "btnExportarVCard";
            this.btnExportarVCard.Size = new System.Drawing.Size(174, 37);
            this.btnExportarVCard.TabIndex = 2;
            this.btnExportarVCard.Text = "Exportar VCard";
            this.btnExportarVCard.UseVisualStyleBackColor = true;
            this.btnExportarVCard.Click += new System.EventHandler(this.btnExportarVCard_Click);
            // 
            // vOlverToolStripMenuItem
            // 
            this.vOlverToolStripMenuItem.Name = "vOlverToolStripMenuItem";
            this.vOlverToolStripMenuItem.Size = new System.Drawing.Size(74, 27);
            this.vOlverToolStripMenuItem.Text = "Volver";
            this.vOlverToolStripMenuItem.Click += new System.EventHandler(this.vOlverToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.btnExportarCSV);
            this.groupBox1.Controls.Add(this.btnExportarVCard);
            this.groupBox1.Location = new System.Drawing.Point(78, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 157);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exportar Archivos";
            // 
            // FrmExportarContactos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 317);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmExportarContactos";
            this.Text = "FrmExportarContactos";
            this.Load += new System.EventHandler(this.FrmExportarContactos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vOlverToolStripMenuItem;
        private System.Windows.Forms.Button btnExportarCSV;
        private System.Windows.Forms.Button btnExportarVCard;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}