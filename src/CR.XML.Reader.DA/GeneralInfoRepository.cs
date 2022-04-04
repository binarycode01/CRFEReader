using CR.XML.Reader.Entities;
using Microsoft.Extensions.Logging;
using System.Data;
using Dapper;

namespace CR.XML.Reader.DA
{
    public class GeneralInfoRepository
    {
        #region Atributes
        private readonly IDbConnection connection;
        private readonly ILogger logger;
        #endregion

        #region Contructor
        public GeneralInfoRepository (IDbConnection connection, ILogger<GeneralInfoRepository> logger)
        {
            this.connection = connection;
            this.logger = logger;
        }
        #endregion

        #region Públic Methods
        public GeneralInfoDTO GetGeneralInfo()
        {
            GeneralInfoDTO dto = new GeneralInfoDTO();

            try
            {
                dto.TotalCompanies = this.connection.ExecuteScalar<int>(Query.TotalCompanies);
                dto.TotalDocuments = this.connection.ExecuteScalar<int>(Query.TotalDocuments);

                var dates = this.connection.Query<dynamic>(Query.BetweenDates).FirstOrDefault();

                if (dates is null)
                    throw new Exception("Please check DB query");
                
                dto.MinDate = DateTime.Parse(dates.FechaMinima); 
                dto.MaxDate = DateTime.Parse(dates.FechaMaxima);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return dto;
        }
        #endregion
    }
}
