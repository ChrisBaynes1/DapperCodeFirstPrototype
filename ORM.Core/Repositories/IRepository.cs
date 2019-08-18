namespace Translator.Core.Repositories
{
    public interface IRepository<T>
    {
        void Update(T entity);
        void Insert(T entity);
        void Replace(T entity);
        void InsertIgnore(T entity);
        void Delete(T entity);
        void Init();
    }
}
