using CR.XML.Reader.Entities;

namespace CR.XML.Reader.BL;

public interface IParseDocumentBL
{
    public IDocCR? Parse(string text);
}
