using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.XML.Reader.Test
{
    internal class FakeLogger : ILogger
    {
        private StringBuilder _log = new StringBuilder();

        public IDisposable BeginScope<TState>(TState state)
        {
            return default!;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            _log.AppendLine(state.ToString());
        }

        public string GetLog 
        { get
            {
                return  _log.ToString();
            }
        }
    }
}
