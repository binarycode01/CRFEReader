namespace CR.XML.Reader.WinUI
{
    partial class frmExportData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportData));
            this.lblCompanies = new System.Windows.Forms.Label();
            this.cbxSociedad = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.rbtEmission = new System.Windows.Forms.RadioButton();
            this.rdbReception = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblCompanies
            // 
            this.lblCompanies.AutoSize = true;
            this.lblCompanies.Location = new System.Drawing.Point(23, 18);
            this.lblCompanies.Name = "lblCompanies";
            this.lblCompanies.Size = new System.Drawing.Size(58, 15);
            this.lblCompanies.TabIndex = 0;
            this.lblCompanies.Text = "Sociedad:";
            // 
            // cbxSociedad
            // 
            this.cbxSociedad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxSociedad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSociedad.FormattingEnabled = true;
            this.cbxSociedad.Location = new System.Drawing.Point(87, 15);
            this.cbxSociedad.Name = "cbxSociedad";
            this.cbxSociedad.Size = new System.Drawing.Size(518, 23);
            this.cbxSociedad.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(87, 46);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtpStartDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha Inicio:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(330, 52);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(69, 15);
            this.lblEndDate.TabIndex = 4;
            this.lblEndDate.Text = "Fecha Final:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(405, 46);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEndDate.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(12, 117);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(590, 58);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Exportar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // rbtEmission
            // 
            this.rbtEmission.AutoSize = true;
            this.rbtEmission.Checked = true;
            this.rbtEmission.Location = new System.Drawing.Point(90, 81);
            this.rbtEmission.Name = "rbtEmission";
            this.rbtEmission.Size = new System.Drawing.Size(67, 19);
            this.rbtEmission.TabIndex = 7;
            this.rbtEmission.TabStop = true;
            this.rbtEmission.Text = "Emisión";
            this.rbtEmission.UseVisualStyleBackColor = true;
            // 
            // rdbReception
            // 
            this.rdbReception.AutoSize = true;
            this.rdbReception.Location = new System.Drawing.Point(207, 81);
            this.rdbReception.Name = "rdbReception";
            this.rdbReception.Size = new System.Drawing.Size(80, 19);
            this.rdbReception.TabIndex = 8;
            this.rdbReception.TabStop = true;
            this.rdbReception.Text = "Recepción";
            this.rdbReception.UseVisualStyleBackColor = true;
            // 
            // frmExportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 187);
            this.Controls.Add(this.rdbReception);
            this.Controls.Add(this.rbtEmission);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.cbxSociedad);
            this.Controls.Add(this.lblCompanies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmExportData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar Datos";
            this.Load += new System.EventHandler(this.frmExportData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblCompanies;
        private ComboBox cbxSociedad;
        private DateTimePicker dtpStartDate;
        private Label label1;
        private Label lblEndDate;
        private DateTimePicker dtpEndDate;
        private Button btnExport;
        private RadioButton rbtEmission;
        private RadioButton rdbReception;
    }
}