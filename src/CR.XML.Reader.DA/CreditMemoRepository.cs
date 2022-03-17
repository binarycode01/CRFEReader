using CR.XML.Reader.Entities.XSD.v43.NotaCredito;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class CreditMemoRepository : GenericDocRepository<NotaCreditoElectronica> 
    {
        #region Constructors
        public CreditMemoRepository(IDbConnection connection) : base(connection)
        { }
        #endregion

        #region Overrides
        protected override string TableName { get { return "NotaCredito"; } }

        public override void AddDocument(NotaCreditoElectronica entity)
        {
            // TODO: Add complete structure. 
            this.Connection.Execute("Insert into NotaCredito values (@Clave, @Consecutivo)", new
            {
                Clave = entity.Clave,
                Consecutivo = entity.NumeroConsecutivo
            });
        }
        #endregion 
    }
}
