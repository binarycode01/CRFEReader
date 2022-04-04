using CR.XML.Reader.Entities;
using System.Xml.Serialization;

namespace CR.XML.Reader.BL
{
    public class ParseDocumentBL : IParseDocumentBL
    {
        #region Públic Methods
        public IDocCR? Parse(string text)
        {
            try
            {
                Type type = new ParseXMLType().GetXMLType(text);
                
                XmlSerializer serializer = new XmlSerializer(type);

                var document = serializer.Deserialize(ParseDocumentBL.TextToStream(text));

                if (document is null)
                {
                    throw new Exception(Messages.InvalidXMLDocument);
                }

                return (IDocCR)document;
            }
            catch {}

            return null;
        }
        #endregion

        #region Private Methods
        private static Stream TextToStream(string text)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        #endregion 
    }
}