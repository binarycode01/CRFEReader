using CR.XML.Reader.Entities.XSD.v43.Factura;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class InvoiceRepository : GenericDocRepository<FacturaElectronica>
    {
        #region Constructors
        public InvoiceRepository (IDbConnection connection) : base (connection) { }

        #endregion

        #region Overrides
        protected override string TableName { get { return "Factura"; } }

        public override void AddDocument(FacturaElectronica entity)
        {
            this.Connection.Execute("Insert into Factura values (@Clave, @Consecutivo)", new
            {
                Clave = entity.Clave,
                Consecutivo = entity.NumeroConsecutivo
            });
        }
        #endregion 
    }
}