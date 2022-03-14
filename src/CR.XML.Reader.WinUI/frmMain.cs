namespace CR.XML.Reader
{
    public partial class frmMain : Form
    {
        #region Contructors
        public frmMain()
        {
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
        #endregion 
    }
}