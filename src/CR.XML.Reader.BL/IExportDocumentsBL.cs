using CR.XML.Reader.Entities;

namespace CR.XML.Reader.BL;
public interface IExportDocumentsBL
{
    public byte[] Export(string Id, DateTime startDate, DateTime endDate, DocModeEnum mode);
}
