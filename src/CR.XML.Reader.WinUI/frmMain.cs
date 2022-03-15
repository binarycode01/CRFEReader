using CR.XML.Reader.BL;
using CR.XML.Reader.DA;
using CR.XML.Reader.WinUI;
using System.Data;

namespace CR.XML.Reader
{
    public partial class frmMain : Form
    {
        #region Atributes
        private readonly IParseDocumentBL ParseBL;
        private readonly IInvoiceRepository repository;
        #endregion

        #region Contructors
        public frmMain(IParseDocumentBL parseBL, IInvoiceRepository repository)
        {
            this.ParseBL = parseBL;
            this.repository = repository; 
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
                // TODO: Exception manager.
                throw;
            }
        }
        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(txtFolder.Text))
                    throw new Exception("Por favor verifique la ruta");

                string[] files = ScanFolders(txtFolder.Text);

                new SyncFiles(this.ParseBL, this.repository).Process(files);
            }
            catch (Exception ex)
            {
                // TODO: Exception manager.
                throw;
            }
        }
        #endregion

        #region Methods
        private string[] ScanFolders(string path)
        {
            // TODO: Check performance.
            string[] files = Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories);

            return files;
        }
        #endregion
    }
}