using CR.XML.Reader.Entities.XSD.v43.FacturaCompra;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.XML.Reader.DA
{
    public class PurchaseInvoiceRepository : GenericDocRepository<FacturaElectronicaCompra>
    {
        #region Constructor
        public PurchaseInvoiceRepository(IDbConnection connection) : base(connection) { }
        #endregion

        #region Overrides
        protected override string TableName { get { return "FacturaCompra"; } }

        public override void AddDocument(FacturaElectronicaCompra entity)
        {
            this.Connection.Execute("Insert into FacturaCompra values (@Clave, @Consecutivo)", new
            {
                Clave = entity.Clave,
                Consecutivo = entity.NumeroConsecutivo
            });
        }
        #endregion 
    }
}
