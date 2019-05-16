using System.Linq;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.ReadServices
{
    public class RankSortOrderReadService : ABaseService
    {
        public RankSortOrderReadService(WordManagerContext context) : base(context) { }

        public IQueryable<RankSortOrder> All()
        {
            return _context.RankSortOrders;
        }

        public RankSortOrder Find(long id)
        {
            return _context.RankSortOrders.Find(id);
        }
    }
}
