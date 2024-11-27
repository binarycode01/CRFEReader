using Microsoft.Extensions.Logging;

namespace CR.XML.Reader.BL;

public class FilePercentageLog
{
    #region Atributes
    private readonly ILogger logger;
    decimal countFiles;
    int totalFiles;
    int steps = 0;
    #endregion

    #region Contants
    private const int Step = 10;
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
    #endregion

    #region Public Methods
    public void Log()
    {
        countFiles++;

        if (steps < Percentage)
        {
            steps += Step;
            logger.LogTrace($"Avance: {Percentage:0.##}%");
        }
    }
    #endregion 
}
