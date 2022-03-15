using CR.XML.Reader.Entities.XSD.v43.Factura;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class InvoiceRepository : IInvoiceRepository
    {
        #region Atributes
        private readonly IDbConnection Connection;
        #endregion

        #region Constructors
        public InvoiceRepository (IDbConnection connection)
        {
            Connection = connection;
        }
        #endregion 

        #region Public Methods
        public void Save(FacturaElectronica invoice)
        {
            try
            {
                this.Connection.Execute("Insert into Factura values (@Clave, @Consecutivo)", new
                {
                    Clave = invoice.Clave,
                    Consecutivo = invoice.NumeroConsecutivo
                });
            }
            catch (Exception ex)
            {
                // TODO: Error 
                throw;
            }
        }
        #endregion 
    }
}
