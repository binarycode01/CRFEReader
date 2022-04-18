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

                ws.Columns[1].Style.Numberformat.Format = "dd/MM/yyyy";
                ws.Row(1).Style.Font.Bold = true;

                return package.GetAsByteArray();
            }
        }

        private DataTable GetPivotData(List<ExportDocumentDTO> documents, List<ExportTaxesDocumentDTO> taxes)
        {
            var headers = taxes.Select(t => new { t.Codigo, t.Tarifa }).Distinct().
                                Select(x => new { value = $"{x.Codigo} - {x.Tarifa}%" });
            var dataTaxes = new DataTable();

            DataTable dataDocuments = createStructureDocuments();

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

        private static DataTable createStructureDocuments()
        {
            var dataDocuments = new DataTable();
            dataDocuments.Columns.Add("FechaEmision", typeof(DateTime));
            dataDocuments.Columns.Add("NumeroConsecutivo", typeof(string));
            dataDocuments.Columns.Add("Clave", typeof(string));
            dataDocuments.Columns.Add("CodigoActividad", typeof(string));
            dataDocuments.Columns.Add("EmisorIdentificacionTipo", typeof(string));
            dataDocuments.Columns.Add("EmisorIdentificacionNumero", typeof(string));
            dataDocuments.Columns.Add("EmisorNombre", typeof(string));
            dataDocuments.Columns.Add("EmisorTelefonoNumTelefono", typeof(string));
            dataDocuments.Columns.Add("EmisorCorreoElectronico", typeof(string));
            dataDocuments.Columns.Add("ReceptorIdentificacionTipo", typeof(string));
            dataDocuments.Columns.Add("ReceptorIdentificacionNumero", typeof(string));
            dataDocuments.Columns.Add("ReceptorIdentificacionExtranjero", typeof(string));
            dataDocuments.Columns.Add("ReceptorNombre", typeof(string));
            dataDocuments.Columns.Add("ReceptorTelefonoCodigoPais", typeof(string));
            dataDocuments.Columns.Add("ReceptorTelefonoNumTelefono", typeof(string));
            dataDocuments.Columns.Add("CondicionVenta", typeof(string));
            dataDocuments.Columns.Add("PlazoCredito", typeof(string));
            dataDocuments.Columns.Add("CodigoTipoMoneda", typeof(string));
            dataDocuments.Columns.Add("Tipo", typeof(string));

            dataDocuments.Columns.Add("TipoCambio", typeof(decimal));
            dataDocuments.Columns.Add("TotalComprobante", typeof(decimal));
            dataDocuments.Columns.Add("TotalExento", typeof(decimal));
            dataDocuments.Columns.Add("TotalExonerado", typeof(decimal));
            dataDocuments.Columns.Add("TotalGravado", typeof(decimal));
            dataDocuments.Columns.Add("TotalImpuesto", typeof(decimal));
            dataDocuments.Columns.Add("TotalIVADevuelto", typeof(decimal));
            dataDocuments.Columns.Add("TotalMercanciasExentas", typeof(decimal));
            dataDocuments.Columns.Add("TotalMercanciasGravadas", typeof(decimal));
            dataDocuments.Columns.Add("TotalMercExonerada", typeof(decimal));
            dataDocuments.Columns.Add("TotalOtrosCargos", typeof(decimal));
            dataDocuments.Columns.Add("TotalServExentos", typeof(decimal));
            dataDocuments.Columns.Add("TotalServExonerado", typeof(decimal));
            dataDocuments.Columns.Add("TotalVenta", typeof(decimal));
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
