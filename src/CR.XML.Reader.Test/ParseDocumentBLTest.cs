using CR.XML.Reader.BL;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using Xunit;

namespace CR.XML.Reader.Test
{
    public class ParseDocumentBLTest
    {
        [Fact]
        public void Parse_Valid_Electronic_Invoice_CR()
        {
            var bl = new ParseDocumentBL();

            var doc = new ParseDocumentBL().Parse(TestResources.RealFEText);

            Assert.IsType<FacturaElectronica>(doc);
        }

        [Fact]
        public void Parse_Valid_Credit_Note_CR()
        {
            var bl = new ParseDocumentBL();

            var doc = new ParseDocumentBL().Parse(TestResources.RealNCText);

            Assert.IsType<Entities.XSD.v43.NotaCredito.NotaCreditoElectronica>(doc);
        }

        [Fact]
        public void Parse_Invalid_XML_Document()
        {
            var bl = new ParseDocumentBL();

            var doc = new ParseDocumentBL().Parse(TestResources.InvalidXML);

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
