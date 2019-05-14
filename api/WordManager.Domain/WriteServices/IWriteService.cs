using Wordmanager.Data.Entities;

namespace WordManager.Domain.WriteServices
{
    public interface IWriteService<T> where T : IEntity
    {
        T Create(T entity);
        bool Delete(T entity);
        T Update(T entity);
    }
}
