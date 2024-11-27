using CR.XML.Reader.BL;
using CR.XML.Reader.DA;
using Microsoft.Extensions.Logging;

namespace CR.XML.Reader.WinUI;

public partial class frmExportData : Form
{
    #region Atributes
    private readonly ILogger logger;
    private readonly CompanyRepository companyRepository;
    private readonly ExportDocumentsBL exportBL;
    #endregion

    #region Constructors
    public frmExportData(ILogger<frmExportData> logger, CompanyRepository companyRepository, ExportDocumentsBL exportDocumentsBL)
    {
        InitializeComponent();
        this.logger = logger;
        this.companyRepository = companyRepository;
        this.exportBL = exportDocumentsBL;
    }
    #endregion

    #region Events
    private void frmExportData_Load(object sender, EventArgs e)
    {
        try
        {
            LoadData();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportData();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
    }
    #endregion

    #region Private Methods
    private void LoadData()
    {
        cbxSociedad.DataSource = companyRepository.GetCompanies();
        cbxSociedad.DisplayMember = "Name";
        cbxSociedad.ValueMember = "Identification";

        var today = DateTime.Today;

        var startDate = new DateTime(today.Year, today.Month, 1);
        startDate = startDate.AddMonths(-1);

        var endDate = new DateTime(today.Year, today.Month, 1);
        endDate = endDate.AddDays(-1);

        dtpStartDate.Value = startDate; 
        dtpEndDate.Value = endDate;
    }

    private void ExportData()
    {
        logger.LogInformation("Exportando datos. Por favor espere");

        using (FileDialog fd = new SaveFileDialog())
        {
            fd.Filter = "Excel Files(.xlsx)|*.xlsx";

            var result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                File.WriteAllBytes(fd.FileName,
                         exportBL.Export((string)cbxSociedad.SelectedValue,
                          dtpStartDate.Value,
                          dtpEndDate.Value,
                           rbtEmission.Checked ? Entities.DocModeEnum.Emission : Entities.DocModeEnum.Reception
                          ));

                logger.LogInformation($"Archivo creado {fd.FileName}");
            }
        }
    }
    #endregion
}
