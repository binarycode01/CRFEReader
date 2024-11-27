namespace CR.XML.Reader;

partial class frmSyncFolder
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSyncFolder));
        this.fdlScanFolder = new System.Windows.Forms.FolderBrowserDialog();
        this.txtFolder = new System.Windows.Forms.TextBox();
        this.lblFolder = new System.Windows.Forms.Label();
        this.btnLoad = new System.Windows.Forms.Button();
        this.btnSync = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // txtFolder
        // 
        this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtFolder.Location = new System.Drawing.Point(131, 12);
        this.txtFolder.Name = "txtFolder";
        this.txtFolder.Size = new System.Drawing.Size(366, 23);
        this.txtFolder.TabIndex = 0;
        // 
        // lblFolder
        // 
        this.lblFolder.AutoSize = true;
        this.lblFolder.Location = new System.Drawing.Point(25, 15);
        this.lblFolder.Name = "lblFolder";
        this.lblFolder.Size = new System.Drawing.Size(100, 15);
        this.lblFolder.TabIndex = 1;
        this.lblFolder.Text = "Carpeta a Revisar:";
        // 
        // btnLoad
        // 
        this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnLoad.Location = new System.Drawing.Point(503, 12);
        this.btnLoad.Name = "btnLoad";
        this.btnLoad.Size = new System.Drawing.Size(75, 23);
        this.btnLoad.TabIndex = 2;
        this.btnLoad.Text = "Cargar";
        this.btnLoad.UseVisualStyleBackColor = true;
        this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
        // 
        // btnSync
        // 
        this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSync.Location = new System.Drawing.Point(25, 41);
        this.btnSync.Name = "btnSync";
        this.btnSync.Size = new System.Drawing.Size(553, 46);
        this.btnSync.TabIndex = 3;
        this.btnSync.Text = "Sincronizar";
        this.btnSync.UseVisualStyleBackColor = true;
        this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
        // 
        // frmSyncFolder
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(594, 103);
        this.Controls.Add(this.btnSync);
        this.Controls.Add(this.btnLoad);
        this.Controls.Add(this.lblFolder);
        this.Controls.Add(this.txtFolder);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Name = "frmSyncFolder";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Lector de archivos XML - Facturación Electrónica CR";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private FolderBrowserDialog fdlScanFolder;
    private TextBox txtFolder;
    private Label lblFolder;
    private Button btnLoad;
    private Button btnSync;
}