using CR.XML.Reader.BL;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace CR.XML.Reader.Test;

public class ParseXMLTypeTest
{
    [Fact]
    public void Parse_Valid_Invoice_XML_Type()
    {
        var bl = new ParseXMLType();
        
        var type = bl.GetXMLType(TestResources.RealFEText);

        Assert.Equal(typeof(FacturaElectronica), type);
    }

    [Fact]
    public void Parse_Invalid_XML()
    {
        var bl = new ParseXMLType();

        Assert.Throws<NotImplementedException>(() => bl.GetXMLType(TestResources.InvalidXML));
    }

    [Fact]
    public void Parse_Invalid_Text()
    {
        var bl = new ParseXMLType();

        Assert.Throws<XmlException>(() => bl.GetXMLType("Not Valid XML Text"));
    }
}
