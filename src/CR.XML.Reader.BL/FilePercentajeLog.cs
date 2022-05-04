using Microsoft.Extensions.Logging;

namespace CR.XML.Reader.BL
{
    public class FilePercentageLog
    {
        #region Atributes
        private readonly ILogger logger;
        decimal countFiles;
        int totalFiles;
        #endregion

        #region Contants
        private const int Steps = 10;
        #endregion 

        #region Contructors
        public FilePercentageLog (ILogger logger, int totalFiles)
        {
            this.logger = logger;
            this.totalFiles = totalFiles;
        }
        #endregion

        #region Properties
        public decimal Percentage 
        { 
            get
            {
                return (countFiles / totalFiles) * 100;
            }
        }

        public bool PrintLog
        {
            get 
            { 
                return Percentage % Steps == 0 ? true : false;
            }
        }
        #endregion

        #region Public Methods
        public void Log()
        {
            countFiles++;

            if (PrintLog)
            {
                logger.LogTrace($"Avance: {Percentage}%");
            }
        }
        #endregion 
    }
}
