using CR.XML.Reader.Entities;
using System.Xml.Serialization;

namespace CR.XML.Reader.BL
{
    public class ParseDocumentBL : IParseDocumentBL
    {
        public IDocCR Parse(string text)
        {
            try
            {
                // TODO: Check Stream or Text usage... 
                Type type = new ParseXMLType().GetXMLType(text);
                
                XmlSerializer serializer = new XmlSerializer(type);

                var document = serializer.Deserialize(ParseDocumentBL.TextToStream(text));

                if (document is null)
                {
                    throw new Exception("Invalid document");
                }

                return (IDocCR)document;
            }
            catch (Exception ex)
            {
                // TODO: logger 
                //throw;
            }

            return null;
        }

        private static Stream TextToStream(string text)
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