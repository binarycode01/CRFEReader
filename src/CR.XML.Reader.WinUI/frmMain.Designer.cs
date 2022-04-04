namespace CR.XML.Reader.WinUI
{
    partial class frmMain
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
            this.syncFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotalCompanies = new System.Windows.Forms.Label();
            this.lblTotalDocuments = new System.Windows.Forms.Label();
            this.lblMinDateMaxDate = new System.Windows.Forms.Label();
            this.lblCompaniesData = new System.Windows.Forms.Label();
            this.lblDocumentsData = new System.Windows.Forms.Label();
            this.lblDatesData = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncFilesToolStripMenuItem,
            this.exportarDatosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(617, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // syncFilesToolStripMenuItem
            // 
            this.syncFilesToolStripMenuItem.Name = "syncFilesToolStripMenuItem";
            this.syncFilesToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.syncFilesToolStripMenuItem.Text = "Sincronizar Archivos";
            this.syncFilesToolStripMenuItem.Click += new System.EventHandler(this.syncFilesToolStripMenuItem_Click);
            // 
            // exportarDatosToolStripMenuItem
            // 
            this.exportarDatosToolStripMenuItem.Name = "exportarDatosToolStripMenuItem";
            this.exportarDatosToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.exportarDatosToolStripMenuItem.Text = "Exportar Datos";
            // 
            // lblTotalCompanies
            // 
            this.lblTotalCompanies.AutoSize = true;
            this.lblTotalCompanies.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCompanies.Location = new System.Drawing.Point(59, 45);
            this.lblTotalCompanies.Name = "lblTotalCompanies";
            this.lblTotalCompanies.Size = new System.Drawing.Size(207, 21);
            this.lblTotalCompanies.TabIndex = 1;
            this.lblTotalCompanies.Text = "Total Sociedades Emisión:";
            // 
            // lblTotalDocuments
            // 
            this.lblTotalDocuments.AutoSize = true;
            this.lblTotalDocuments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDocuments.Location = new System.Drawing.Point(113, 114);
            this.lblTotalDocuments.Name = "lblTotalDocuments";
            this.lblTotalDocuments.Size = new System.Drawing.Size(153, 21);
            this.lblTotalDocuments.TabIndex = 2;
            this.lblTotalDocuments.Text = "Total Documentos:";
            // 
            // lblMinDateMaxDate
            // 
            this.lblMinDateMaxDate.AutoSize = true;
            this.lblMinDateMaxDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMinDateMaxDate.Location = new System.Drawing.Point(12, 191);
            this.lblMinDateMaxDate.Name = "lblMinDateMaxDate";
            this.lblMinDateMaxDate.Size = new System.Drawing.Size(254, 21);
            this.lblMinDateMaxDate.TabIndex = 3;
            this.lblMinDateMaxDate.Text = "Rango de fecha de documentos:";
            // 
            // lblCompaniesData
            // 
            this.lblCompaniesData.AutoSize = true;
            this.lblCompaniesData.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCompaniesData.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblCompaniesData.Location = new System.Drawing.Point(272, 26);
            this.lblCompaniesData.Name = "lblCompaniesData";
            this.lblCompaniesData.Size = new System.Drawing.Size(37, 45);
            this.lblCompaniesData.TabIndex = 4;
            this.lblCompaniesData.Text = "0";
            // 
            // lblDocumentsData
            // 
            this.lblDocumentsData.AutoSize = true;
            this.lblDocumentsData.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDocumentsData.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblDocumentsData.Location = new System.Drawing.Point(272, 95);
            this.lblDocumentsData.Name = "lblDocumentsData";
            this.lblDocumentsData.Size = new System.Drawing.Size(37, 45);
            this.lblDocumentsData.TabIndex = 5;
            this.lblDocumentsData.Text = "0";
            // 
            // lblDatesData
            // 
            this.lblDatesData.AutoSize = true;
            this.lblDatesData.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDatesData.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblDatesData.Location = new System.Drawing.Point(272, 172);
            this.lblDatesData.Name = "lblDatesData";
            this.lblDatesData.Size = new System.Drawing.Size(324, 45);
            this.lblDatesData.TabIndex = 6;
            this.lblDatesData.Text = "1-feb-22 al 4-abril-22";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 425);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(617, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "Base de datos:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel2.Text = "DBNAME.DB";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblDatesData);
            this.Controls.Add(this.lblDocumentsData);
            this.Controls.Add(this.lblCompaniesData);
            this.Controls.Add(this.lblMinDateMaxDate);
            this.Controls.Add(this.lblTotalDocuments);
            this.Controls.Add(this.lblTotalCompanies);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documentos Electrónicos Costa Rica";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem syncFilesToolStripMenuItem;
        private Label lblTotalCompanies;
        private Label lblTotalDocuments;
        private Label lblMinDateMaxDate;
        private Label lblCompaniesData;
        private Label lblDocumentsData;
        private Label lblDatesData;
        private ToolStripMenuItem exportarDatosToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
    }
}