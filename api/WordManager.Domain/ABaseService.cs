using Wordmanager.Data;

namespace WordManager.Domain
{
    public abstract class ABaseService
    {
        protected readonly WordManagerContext _context;

        public ABaseService(WordManagerContext context)
        {
            _context = context;
        }
    }
}
