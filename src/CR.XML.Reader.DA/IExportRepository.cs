using CR.XML.Reader.Entities;

namespace CR.XML.Reader.DA
{
    public interface IExportRepository
    {
        List<ExportDocumentDTO> GetExpenses(string Id, DateTime startDate, DateTime endDate);
        List<ExportTaxesDocumentDTO> GetExpensesTaxes(string Id, DateTime startDate, DateTime endDate);
        List<ExportDocumentDTO> GetSales(string Id, DateTime startDate, DateTime endDate);
        List<ExportTaxesDocumentDTO> GetSalesTaxes(string Id, DateTime startDate, DateTime endDate);
    }
}