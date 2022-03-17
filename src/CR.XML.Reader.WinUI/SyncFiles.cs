using CR.XML.Reader.BL;

namespace CR.XML.Reader.WinUI
{
    internal class SyncFiles
    {
        #region Atributes
        private readonly IParseDocumentBL parser;
        private readonly ISyncDocumentBL syncBL;
        
        // TODO: Add progress bar
        #endregion

        #region Constructors
        public SyncFiles(IParseDocumentBL parserBL, ISyncDocumentBL syncBL)
        {
            this.parser = parserBL;
            this.syncBL = syncBL;
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

                    if (doc != null)
                    {
                        this.syncBL.SyncDocument(doc);
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
