using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CR.XML.Reader.WinUI
{
    public partial class frmMain : Form
    {
        #region Atributes
        private readonly ServiceProvider serviceProvider;
        private readonly ILogger<frmMain> logger;
        #endregion

        #region Contructors
        public frmMain(ServiceProvider serviceProvider)
        {
            InitializeComponent();

            this.serviceProvider = serviceProvider;
            logger = serviceProvider.GetRequiredService<ILogger<frmMain>>();
        }
        #endregion

        #region Events
        private void syncFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = serviceProvider.GetRequiredService<frmSyncFolder>();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
        #endregion 
    }
}
