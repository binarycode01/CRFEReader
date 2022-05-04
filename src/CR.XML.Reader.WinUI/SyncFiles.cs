using CR.XML.Reader.BL;
using Microsoft.Extensions.Logging;
using System.IO.Compression;

namespace CR.XML.Reader.WinUI
{
    internal class SyncFiles
    {
        #region Atributes
        private readonly IParseDocumentBL parser;
        private readonly ISyncDocumentBL syncBL;
        private readonly ILogger logger;
        
        int result = 0;
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
            
            try
            {
                var fp = new FilePercentageLog(logger, files.Length);

                foreach (var item in files)
                {
                    if (item.EndsWith(".zip"))
                    {
                        SearchOnZipFile(item);
                    }
                    else
                    {
                        string text = string.Empty;
                        text = File.ReadAllText(item);

                        TryToSyncDoc(text);
                    }

                    fp.Log();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return result;
        }
        #endregion

        #region Private Methods
        private void TryToSyncDoc(string text)
        {
            var doc = this.parser.Parse(text);

            if (doc != null)
            {
                if (this.syncBL.SyncDocument(doc))
                {
                    result++;
                }
            }
        }

        private void SearchOnZipFile(string item)
        {
            var lenghtFile = new FileInfo(item).Length;

            // Skip large files.
            if (lenghtFile >= 102400) // TODO: Hardcoded.
                return;

            using (var file = File.OpenRead(item))
            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            {
                foreach (var itemzip in zip.Entries)
                {
                    // Skip another kind of files.
                    if (!itemzip.FullName.EndsWith(".xml"))
                        continue;

                    using (var stream = itemzip.Open())
                    {
                        StreamReader reader = new StreamReader(stream);
                        var text = reader.ReadToEnd();
                        
                        TryToSyncDoc(text);
                    }
                }
            }
        }
        #endregion
    }
}
