using CR.XML.Reader.BL;
using CR.XML.Reader.DA;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using System.Data;

namespace CR.XML.Reader.WinUI
{
    internal class SyncFiles
    {
        #region Atributes
        private IParseDocumentBL parser;
        private IDbConnection dbConnection;
        private readonly IInvoiceRepository repository;
        // TODO: Add progress bar
        #endregion

        #region Constructors
        public SyncFiles(IParseDocumentBL parserBL, IInvoiceRepository repository)
        {
            this.parser = parserBL;
            this.repository = repository;
            //this.dbConnection = connection;
        }
        #endregion 

        #region Públic Methods
        public void Process(string[] files)
        {
            try
            {
                foreach (var item in files)
                {
                    string text = File.ReadAllText(item);
                    var doc = this.parser.Parse(text);

                    // TODO: Remove crap
                    if (doc != null && doc is FacturaElectronica)
                    {
                        // TODO: Boxing / UnBoxing problem.
                        repository.Save((FacturaElectronica)doc);
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: Logger / error
                throw;
            }
        }
        #endregion 
    }
}
