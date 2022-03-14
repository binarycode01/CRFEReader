using CR.XML.Reader.BL;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CR.XML.Reader.Test
{
    public class ParseDocumentBLTest
    {
        [Fact]
        public void Parse_Valid_Electronic_Invoice_CR()
        {
            var bl = new ParseDocumentBL();

            Stream mem = StringToSteam(TestResources.RealFEText);
            var doc = bl.Parse(mem);

            Assert.IsType<FacturaElectronica>(doc);
        }

        [Fact]
        public void Parse_Invalid_XML_Document()
        {
            var bl = new ParseDocumentBL();

            Stream mem = StringToSteam(TestResources.InvalidXML);
            var doc = bl.Parse(mem);

            Assert.Null(doc);
        }


        private Stream StringToSteam(string text)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
