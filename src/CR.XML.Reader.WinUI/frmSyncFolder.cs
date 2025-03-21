namespace CR.XML.Reader;

using CR.XML.Reader.BL;
using CR.XML.Reader.WinUI;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Data;

public partial class frmSyncFolder : Form
{
    #region Atributes
    private readonly IParseDocumentBL ParseBL;
    private readonly ISyncDocumentBL SyncBL;
    private readonly ILogger<frmSyncFolder> logger;
    #endregion

    #region Contructors
    public frmSyncFolder(IParseDocumentBL parseBL, ISyncDocumentBL syncBL, ILogger<frmSyncFolder> logger)
    {
        this.ParseBL = parseBL;
        this.SyncBL = syncBL;
        this.logger = logger; 
        InitializeComponent();
    }
    #endregion

    #region Events
    private void btnLoad_Click(object sender, EventArgs e)
    {
        try
        {
            var result = this.fdlScanFolder.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFolder.Text = fdlScanFolder.SelectedPath;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
    }
    private void btnSync_Click(object sender, EventArgs e)
    {
        try
        {
            this.Cursor = Cursors.WaitCursor;
            this.btnSync.Enabled = false;


            var bw = new BackgroundWorker();
            bw.DoWork += Bw_SyncFolder;

            bw.RunWorkerCompleted += Bw_CompletedSyncFolder;

            bw.RunWorkerAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
    }

    private void Bw_CompletedSyncFolder(object? sender, RunWorkerCompletedEventArgs e)
    {
        this.Cursor = Cursors.Default;
        this.btnSync.Enabled = true;
    }

    private void Bw_SyncFolder(object? sender, DoWorkEventArgs e)
    {
        try
        {
            if (!Directory.Exists(txtFolder.Text))
                throw new Exception("Por favor verifique la ruta");

            string[] files = ScanFolders(txtFolder.Text);

            var result = new SyncFiles(this.ParseBL, this.SyncBL, logger).Process(files);

            logger.LogInformation($"Total documentos sincronizados: {result}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
            
    }
    #endregion

    #region Private Methods
    private string[] ScanFolders(string path)
    {
        // TODO: Check performance.
        var allowedExtensions = new[] { ".xml", ".zip"};

        string[] files = Directory.GetFiles(path,"*.*",SearchOption.AllDirectories)
                                    .Where(file => allowedExtensions.Any(file.ToLower().EndsWith))
                                    .ToArray();

        logger.Log(LogLevel.Information, $"Analizando {files.Count()} archivos.");

        return files;
    }
    #endregion
}
