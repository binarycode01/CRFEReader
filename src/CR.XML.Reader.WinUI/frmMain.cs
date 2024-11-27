using CR.XML.Reader.DA;
using CR.XML.Reader.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CR.XML.Reader.WinUI;

public partial class frmMain : Form
{
    #region Atributes
    private readonly ServiceProvider serviceProvider;
    private readonly ILogger<frmMain> logger;
    private readonly GeneralInfoRepository repository;
    private readonly string dbFile;
    #endregion

    #region Contructors
    public frmMain(ServiceProvider serviceProvider, string dbFile)
    {
        InitializeComponent();

        this.serviceProvider = serviceProvider;
        logger = serviceProvider.GetRequiredService<ILogger<frmMain>>();

        this.repository = serviceProvider.GetRequiredService<GeneralInfoRepository>();

        this.dbFile = dbFile;
    }
    #endregion

    #region Events
    private void frmMain_Load(object sender, EventArgs e)
    {
        try
        {
            loadData(repository.GetGeneralInfo());
            lbldbFullPath.Text = Path.GetFullPath(dbFile);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
    }

    private void syncFilesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            var frm = serviceProvider.GetRequiredService<frmSyncFolder>();
            frm.ShowDialog();
            loadData(repository.GetGeneralInfo());
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
    }

    private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            var frm = serviceProvider.GetRequiredService<frmExportData>();
            frm.ShowDialog();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
    }
    #endregion

    #region Private Methods
    private void loadData(GeneralInfoDTO generalInfoDTO)
    {
        this.lblCompaniesData.Text = generalInfoDTO.TotalCompanies.ToString();
        this.lblDocumentsData.Text = generalInfoDTO.TotalDocuments.ToString();
        this.lblDatesData.Text = $"{generalInfoDTO.MinDate.ToShortDateString()} al {generalInfoDTO.MaxDate.ToShortDateString()}";
    }
    #endregion
}
