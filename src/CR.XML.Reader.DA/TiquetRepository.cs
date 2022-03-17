using CR.XML.Reader.Entities.XSD.v43.Tiquete;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class TiquetRepository : IRepository<TiqueteElectronico>
    {
        #region Atributes
        private readonly IDbConnection Connection;
        #endregion

        #region Contructors
        public TiquetRepository (IDbConnection connection)
        {
            this.Connection = connection; 
        }
        #endregion

        #region Métodos públicos
        public void Save(TiqueteElectronico entity)
        {
            try
            {
                this.Connection.Execute("Insert into Tiquete values (@Clave, @Consecutivo)", new
                {
                    Clave = entity.Clave,
                    Consecutivo = entity.NumeroConsecutivo
                });
            }
            catch (Exception ex)
            {
                // TODO: Log / Exception
                throw;
            }
        }
        #endregion 
    }
}
