using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.XML.Reader.BL
{
    public static class TextCleaner
    {
        public static string FixEscapeCaracter(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty);

                // TODO: Check another invalid characters.

                return text.Trim();
            }

            return string.Empty;
        }
    }
}
