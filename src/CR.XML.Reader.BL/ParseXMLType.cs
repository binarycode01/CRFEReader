using CR.XML.Reader.Entities;
using System.Xml;

namespace CR.XML.Reader.BL;

public class ParseXMLType
{
    public Type GetXMLType(string text)
    {
        
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(TextCleaner.FixEscapeCaracter(text));

        if (xml.DocumentElement is null)
            throw new Exception("Invalid root XML Element");

        string xmlns = xml.DocumentElement.NamespaceURI; // TODO: Check spaces.

        // TODO: Add another types
        switch (xmlns)
        {
            case XmlnsCR.FacturaElectronicaV43:
                return typeof(Entities.XSD.v43.Factura.FacturaElectronica);

            case XmlnsCR.NotaCreditoV43:
                return typeof(Entities.XSD.v43.NotaCredito.NotaCreditoElectronica);
                
            case XmlnsCR.NotaDebitoV43:
                return typeof(Entities.XSD.v43.NotaDebito.NotaDebitoElectronica);

            case XmlnsCR.FacturaElectronicaExportacionV43:
                return typeof(Entities.XSD.v43.FacturaExportacion.FacturaElectronicaExportacion);

            case XmlnsCR.FacturaElectronicaCompraV43:
                return typeof(Entities.XSD.v43.FacturaCompra.FacturaElectronicaCompra);

            case XmlnsCR.TiqueteV43:
                return typeof(Entities.XSD.v43.Tiquete.TiqueteElectronico);

            default:
                throw new NotImplementedException("Invalid XML file");
        }
        
    }
}
