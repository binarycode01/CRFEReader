using CR.XML.Reader.DA;
using CR.XML.Reader.Entities;

namespace CR.XML.Reader.Test;

public class FakeExportRepository : IExportRepository
{
    public List<ExportDocumentDTO> GetExpenses(string Id, DateTime startDate, DateTime endDate)
    {
        List<ExportDocumentDTO> docs = new List<ExportDocumentDTO>();

        docs.Add(new ExportDocumentDTO 
        { 
            Clave = "50601012200112770761000100001010000010100000000001",
            Tipo = "Factura",
            TotalExento = 0,
            TotalGravado = 1024,
            TotalComprobante = 1024,
        });

        return docs;
    }

    public List<ExportTaxesDocumentDTO> GetExpensesTaxes(string Id, DateTime startDate, DateTime endDate)
    {
        var taxes = new List<ExportTaxesDocumentDTO>();

        taxes.Add(new ExportTaxesDocumentDTO
        {
            Clave  = "50601012200112770761000100001010000010100000000001",
            Codigo = "08",
            Tarifa = "13",
            Total  = 133.12m
        });

        return taxes;
    }

    public List<ExportDocumentDTO> GetSales(string Id, DateTime startDate, DateTime endDate)
    {
        List<ExportDocumentDTO> docs = new List<ExportDocumentDTO>();

        docs.Add(new ExportDocumentDTO
        {
            Clave = "50601012200112770761000100001010000010100000000001",
            Tipo = "Factura",
            TotalExento = 0,
            TotalGravado = 1024,
            TotalComprobante = 1024,
        });

        return docs;
    }

    public List<ExportTaxesDocumentDTO> GetSalesTaxes(string Id, DateTime startDate, DateTime endDate)
    {
        var taxes = new List<ExportTaxesDocumentDTO>();

        taxes.Add(new ExportTaxesDocumentDTO
        {
            Clave = "50601012200112770761000100001010000010100000000001",
            Codigo = "08",
            Tarifa = "13",
            Total = 133.12m
        });

        return taxes;
    }
}
