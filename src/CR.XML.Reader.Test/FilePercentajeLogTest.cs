using CR.XML.Reader.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CR.XML.Reader.Test
{
    public class FilePercentageLogTest
    {
        [Theory]
        [InlineData(7)]
        [InlineData(34)]
        [InlineData(178)]
        public void StepsLogTest(int fakeTotalFiles)
        {
            var logFactory = Microsoft.Extensions.Logging.Abstractions.NullLoggerFactory.Instance;
            var logger = logFactory.CreateLogger("test");

            var bl = new FilePercentageLog(logger, fakeTotalFiles);

            for (int i = 0; i < fakeTotalFiles; i++)
            {
                bl.Log();

                var calc = ((decimal)(i + 1) / fakeTotalFiles * 100) % 10;

                if (calc == 0)
                {
                    Assert.True(bl.PrintLog);
                }
                else
                {
                    Assert.False(bl.PrintLog);
                }
            }
        }
    }
}
