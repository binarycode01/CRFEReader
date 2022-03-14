using CR.XML.Reader.Entities;
using CR.XML.Reader.Entities.XSD.v43.Factura;
using System.Xml.Serialization;

namespace CR.XML.Reader.BL
{
    public class ParseDocumentBL
    {
        public IDocCR Parse(Stream text)
        {
            try
            {
                
                // TODO: Add another types...
                XmlSerializer serializer = new XmlSerializer(typeof(FacturaElectronica));

                var document = serializer.Deserialize(text);

                if (document is null)
                {
                    throw new Exception("Invalid document");
                }

                // TODO: Each type.
                return (FacturaElectronica)document;
            }
            catch (Exception ex)
            {
                
                // TODO: logger 
                //throw;
            }

            // Invalid Document
            return null;
        }
    }
}
