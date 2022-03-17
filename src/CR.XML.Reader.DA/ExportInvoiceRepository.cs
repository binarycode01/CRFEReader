using CR.XML.Reader.Entities.XSD.v43.FacturaExportacion;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class ExportInvoiceRepository : GenericDocRepository<FacturaElectronicaExportacion>
    {
        #region Contructors
        public ExportInvoiceRepository (IDbConnection connection) : base(connection) { }
        #endregion

        #region Overrides
        protected override string TableName { get { return "Exportacion"; } }

        public override void AddDocument(FacturaElectronicaExportacion entity)
        {
            this.Connection.Execute("Insert into Exportacion values (@Clave, @Consecutivo)", new
            {
                Clave = entity.Clave,
                Consecutivo = entity.NumeroConsecutivo
            });
        }
        #endregion 
    }
}
