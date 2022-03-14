using System.Xml;
using static CR.XML.Reader.BL.XmlnsCR;

namespace CR.XML.Reader.BL
{
    public class ParseXMLType
    {
        public Type GetXMLType(string text)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(TextCleaner.FixEscapeCaracter(text));

                if (xml.DocumentElement is null)
                {
                    throw new Exception("Invalid root XML Element");
                }

                string xmlns = xml.DocumentElement.NamespaceURI; // TODO: Check spaces.

                // TODO: Add another types
                switch (xmlns)
                {
                    case XmlnsHacienda.FacturaElectronicaV43:
                        return typeof(Entities.XSD.v43.Factura.FacturaElectronica);

                    case XmlnsHacienda.NotaCreditoV43:
                        return typeof(Entities.XSD.v43.NotaCredito.NotaCreditoElectronica);
                    
                    case XmlnsHacienda.NotaDebitoV43:
                        return typeof(Entities.XSD.v43.NotaDebito.NotaDebitoElectronica);

                    case XmlnsHacienda.FacturaElectronicaExportacionV43:
                        return typeof(Entities.XSD.v43.FacturaExportacion.FacturaElectronicaExportacion);

                    case XmlnsHacienda.FacturaElectronicaCompraV43:
                        return typeof(Entities.XSD.v43.FacturaCompra.FacturaElectronicaCompra);

                    case XmlnsHacienda.TiqueteV43:
                        return typeof(Entities.XSD.v43.Tiquete.TiqueteElectronico);

                    default:
                        throw new NotImplementedException("Invalid XML file");
                }
            }
            catch (Exception ex)
            {
                // TODO: Logger / Error.
                throw;
            }
        }
    }
}
