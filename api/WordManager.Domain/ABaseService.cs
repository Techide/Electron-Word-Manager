using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain
{
    public abstract class ABaseService<T> : IBaseService<T> where T : IEntity
    {
        protected readonly WordManagerContext _context;

        public ABaseService(WordManagerContext context)
        {
            _context = context;
        }

        public abstract T Create(T entity);

        public abstract bool Delete(T entity);

        public abstract T Update(T entity);
    }
}
