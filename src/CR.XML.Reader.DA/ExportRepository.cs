using CR.XML.Reader.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class ExportRepository : IExportRepository
    {
        #region Atributes
        private readonly IDbConnection connection;
        private readonly ILogger logger;
        #endregion

        #region Contructors
        public ExportRepository(IDbConnection connection, ILogger<ExportRepository> logger)
        {
            this.connection = connection;
            this.logger = logger;
        }
        #endregion

        #region Public Methods
        public List<ExportDocumentDTO> GetSales(string Id, DateTime startDate, DateTime endDate)
        {
            List<ExportDocumentDTO> results = new List<ExportDocumentDTO>();

            try
            {
                results = connection.Query<ExportDocumentDTO>(Query.ExportSalesHeader, new
                {
                    Id,
                    startDate = startDate.ToString("yyyy-MM-dd"),
                    endDate = endDate.ToString("yyyy-MM-dd")
                }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return results;
        }

        public List<ExportTaxesDocumentDTO> GetSalesTaxes(string Id, DateTime startDate, DateTime endDate)
        {
            List<ExportTaxesDocumentDTO> results = new List<ExportTaxesDocumentDTO>();

            try
            {
                results = connection.Query<ExportTaxesDocumentDTO>(Query.ExportSalesTaxes, new
                {
                    Id,
                    startDate = startDate.ToString("yyyy-MM-dd"),
                    endDate = endDate.ToString("yyyy-MM-dd")
                }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return results;
        }

        public List<ExportDocumentDTO> GetExpenses(string Id, DateTime startDate, DateTime endDate)
        {
            List<ExportDocumentDTO> results = new List<ExportDocumentDTO>();

            try
            {
                results = connection.Query<ExportDocumentDTO>(Query.ExportExpensesHeader, new
                {
                    Id,
                    startDate = startDate.ToString("yyyy-MM-dd"),
                    endDate = endDate.ToString("yyyy-MM-dd")
                }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return results;
        }


        public List<ExportTaxesDocumentDTO> GetExpensesTaxes(string Id, DateTime startDate, DateTime endDate)
        {
            List<ExportTaxesDocumentDTO> results = new List<ExportTaxesDocumentDTO>();

            try
            {
                results = connection.Query<ExportTaxesDocumentDTO>(Query.ExportExpensesTaxes, new
                {
                    Id,
                    startDate = startDate.ToString("yyyy-MM-dd"),
                    endDate = endDate.ToString("yyyy-MM-dd")
                }).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return results;
        }
        #endregion
    }
}
