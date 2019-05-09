using Wordmanager.Data.Entities;

namespace WordManager.Domain
{
    public interface IBaseService<T> where T : IEntity
    {
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}
