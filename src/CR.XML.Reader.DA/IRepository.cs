using CR.XML.Reader.Entities;

namespace CR.XML.Reader.DA
{
    public interface IRepository <in T> where T : IDocCR
    {
        public void Save(T entity);
    }
}
