using CR.XML.Reader.BL;
using Microsoft.Extensions.Logging;

namespace CR.XML.Reader.WinUI
{
    internal class SyncFiles
    {
        #region Atributes
        private readonly IParseDocumentBL parser;
        private readonly ISyncDocumentBL syncBL;
        private readonly ILogger logger;
        // TODO: Add progress bar
        #endregion

        #region Constructors
        public SyncFiles(IParseDocumentBL parserBL, ISyncDocumentBL syncBL, ILogger logger)
        {
            this.parser = parserBL;
            this.syncBL = syncBL;
            this.logger = logger;
        }
        #endregion 

        #region Públic Methods
        public int Process(string[] files)
        {
            int result = 0;
            try
            {
                foreach (var item in files)
                {
                    string text = File.ReadAllText(item);
                    var doc = this.parser.Parse(text);

                    if (doc != null)
                    {
                        if (this.syncBL.SyncDocument(doc))
                        {
                            result++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return result;
        }
        #endregion 
    }
}
