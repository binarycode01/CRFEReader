using CR.XML.Reader.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CR.XML.Reader.DA;

public class CompanyRepository
{
    #region Atributes
    private readonly IDbConnection connection;
    private readonly ILogger logger;
    #endregion

    #region Constructor
    public CompanyRepository (IDbConnection connection, ILogger<CompanyRepository> logger)
    {
        this.connection = connection;
        this.logger = logger;
    }
    #endregion

    #region Public Methods
    public List<CompanyDTO> GetCompanies()
    {
        var companies = new List<CompanyDTO>();

        try
        {
            companies = connection.Query<CompanyDTO>(Query.GetAllCompanies).ToList();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }

        return companies;
    }
    #endregion
}
