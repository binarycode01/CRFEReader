using CR.XML.Reader.DA;
using CR.XML.Reader.Entities;
using FastMember;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System.Data;
using System.Linq;

namespace CR.XML.Reader.BL
{
    public class ExportDocumentsBL : IExportDocumentsBL
    {
        #region Atributes
        private readonly ILogger logger;
        private readonly ExportRepository repository;
        #endregion

        #region Constructor
        public ExportDocumentsBL(ILogger<ExportDocumentsBL> logger, ExportRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        #endregion

        #region Public Methods
        public byte[] Export(string Id, DateTime startDate, DateTime endDate, DocModeEnum mode)
        {
            try
            {
                Validate(Id, startDate, endDate);

                List<ExportDocumentDTO> documents = GetDocuments(Id, startDate, endDate, mode);

                List<ExportTaxesDocumentDTO> taxes = GetTaxes(Id, startDate, endDate, mode);

                return CreateExcel(documents, taxes);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            
            return null;
        }
        #endregion

        #region Private Methods
        private byte[] CreateExcel(List<ExportDocumentDTO> documents, List<ExportTaxesDocumentDTO> taxes)
        {

            using (ExcelPackage package = new ExcelPackage())
            {
                package.Workbook.Worksheets.Add("Sheet 1");
                ExcelWorksheet ws = package.Workbook.Worksheets[0];
                ws.Cells.Style.Font.Size = 11;
                ws.Cells.Style.Font.Name = "Calibri";

                DataTable data = GetPivotData(documents, taxes);

                ws.Cells["A1"].LoadFromDataTable(data, true);
                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }

        private DataTable GetPivotData(List<ExportDocumentDTO> documents, List<ExportTaxesDocumentDTO> taxes)
        {
            var headers = taxes.Select(t => new { t.Codigo, t.Tarifa }).Distinct().
                                Select(x => new { value = $"{x.Codigo} - {x.Tarifa}%" });
            var dataDocuments = new DataTable();
            var dataTaxes = new DataTable();


            dataTaxes.Columns.Add("Clave", typeof(string));

            foreach (var header in headers)
            {
                dataTaxes.Columns.Add(header.value, typeof(decimal));
            }

            var groups = taxes.GroupBy(x => new { x.Clave }).ToList();

            foreach (var item in groups)
            {
                DataRow newRow = dataTaxes.Rows.Add(item.Key.Clave);

                foreach (var row in item)
                {
                    string columnName = $"{row.Codigo} - {row.Tarifa}%";
                    newRow[columnName] = row.Total;
                }
            }
            using (var reader = ObjectReader.Create(documents))
            {
                dataDocuments.Load(reader);
            }

            dataDocuments.PrimaryKey = new DataColumn[]
            {
                dataDocuments.Columns["Clave"]
            };

            dataTaxes.PrimaryKey = new DataColumn[]
            {
                dataTaxes.Columns["Clave"]
            };

            dataDocuments.Merge(dataTaxes);

            return dataDocuments;
        }

        private List<ExportTaxesDocumentDTO> GetTaxes(string id, DateTime startDate, DateTime endDate, DocModeEnum mode)
        {
            List<ExportTaxesDocumentDTO> taxes;

            if (mode == DocModeEnum.Emission)
            {
                taxes = repository.GetSalesTaxes(id, startDate, endDate);
            }
            else
            {
                taxes = repository.GetExpensesTaxes(id, startDate, endDate);
            }

            return taxes;
        }

        private List<ExportDocumentDTO> GetDocuments(string Id, DateTime startDate, DateTime endDate, DocModeEnum mode)
        {
            List<ExportDocumentDTO> documents;
            if (mode == DocModeEnum.Emission)
            {
                documents = repository.GetSales(Id, startDate, endDate);
            }
            else
            {
                documents = repository.GetExpenses(Id, startDate, endDate);
            }

            return documents;
        }

        private static void Validate(string Id, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(Id))
                throw new ArgumentNullException("Invalid Id parameter");

            if (startDate == DateTime.MinValue)
                throw new ArgumentNullException("Invalid start date");

            if (endDate == DateTime.MinValue)
                throw new ArgumentNullException("Invalid end date");
        }
        #endregion 
    }
}
