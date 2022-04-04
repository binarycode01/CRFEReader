using CR.XML.Reader.Entities;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CR.XML.Reader.DA
{
    public abstract class GenericDocRepository<T> : IRepository<T> where T : IDocCR
    {
        #region Atributes
        public readonly IDbConnection Connection;
        private HashSet<string> keys = new HashSet<string>();
        private readonly ILogger logger;
        #endregion

        #region Contructors
        public GenericDocRepository (IDbConnection connection, ILogger logger)
        {
            this.Connection = connection;
            this.logger = logger;
            this.LoadHash();
        }
        #endregion

        #region Private Methods
        private void LoadHash()
        {
            this.keys = this.Connection.Query<string>(String.Format("select Clave from {0}", this.TableName)).ToHashSet<string>();
        }
        #endregion 

        #region Public Methods
        public bool Save(T entity)
        {
            try
            {
                if (keys.Contains(entity.Clave))
                    return false;

                this.AddDocument(entity);

                keys.Add(entity.Clave);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return false;
        }

        
        #endregion

        #region Public Abstracts Methods
        public abstract void AddDocument(T entity);

        protected abstract string TableName { get; }
        #endregion 
    }
}
