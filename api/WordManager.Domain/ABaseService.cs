using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain
{
    public abstract class ABaseService<T> where T : IEntity
    {
        protected readonly WordManagerContext _context;

        public ABaseService(WordManagerContext context)
        {
            _context = context;
        }
    }
}
