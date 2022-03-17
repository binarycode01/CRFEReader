using CR.XML.Reader.Entities.XSD.v43.NotaDebito;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class DebitMemoRepository : GenericDocRepository<NotaDebitoElectronica>
    {
        #region Contructor
        public DebitMemoRepository(IDbConnection connection) : base(connection) { }
        #endregion

        #region Overrides
        protected override string TableName { get { return "NotaDebito"; } }

        public override void AddDocument(NotaDebitoElectronica entity)
        {
            // TODO: Add complete structure. 
            this.Connection.Execute("Insert into NotaDebito values (@Clave, @Consecutivo)", new
            {
                Clave = entity.Clave,
                Consecutivo = entity.NumeroConsecutivo
            });
        }
        #endregion 
    }
}
