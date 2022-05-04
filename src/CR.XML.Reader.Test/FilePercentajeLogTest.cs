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
        [InlineData(1)]
        [InlineData(7)]
        [InlineData(34)]
        [InlineData(177)]
        public void StepsLogTest(int fakeTotalFiles)
        {
            FakeLogger logfake = new FakeLogger();

            var bl = new FilePercentageLog(logfake, fakeTotalFiles);

            for (int i = 0; i < fakeTotalFiles; i++)
            {
                bl.Log();
            }

            var log = logfake.GetLog;

            Assert.False(String.IsNullOrWhiteSpace(log));

        }
    }
}
