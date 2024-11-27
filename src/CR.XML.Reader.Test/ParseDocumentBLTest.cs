using CR.XML.Reader.BL;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using Xunit;

namespace CR.XML.Reader.Test;

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

    [Fact]
    public void Parse_Valid_Tiquet_WithOtherXML()
    {
        var bl = new ParseDocumentBL();

        var doc = new ParseDocumentBL().Parse(TestResources.RealTiquetWithOtherXmls);

        Assert.IsType<Entities.XSD.v43.Tiquete.TiqueteElectronico>(doc);

        Assert.False(string.IsNullOrWhiteSpace(((Entities.XSD.v43.Tiquete.TiqueteElectronico)doc).Otros.OtroContenido[0].Any.InnerXml)) ;
    }
}
