namespace CR.XML.Reader.DA
{
    public interface IRepository <T> where T : class
    {
        public void Save(T entity);
    }
}
