﻿using CR.XML.Reader.Entities.XSD.v43.Tiquete;
using Dapper;
using System.Data;

namespace CR.XML.Reader.DA
{
    public class TiquetRepository : GenericDocRepository<TiqueteElectronico>
    {
        #region Contructors
        public TiquetRepository (IDbConnection connection) : base (connection) { }


        #endregion

        #region Overrides
        protected override string TableName { get { return "Tiquete"; } }

        public override void AddDocument(TiqueteElectronico entity)
        {
            this.Connection.Execute("Insert into Tiquete values (@Clave, @Consecutivo)", new
            {
                Clave = entity.Clave,
                Consecutivo = entity.NumeroConsecutivo
            });
        }
        #endregion 
    }
}
