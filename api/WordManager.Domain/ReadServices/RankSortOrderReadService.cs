using System.Linq;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.ReadServices
{
    public class RankSortOrderReadService : ABaseService<RankSortOrder>, IReadService<RankSortOrder>
    {
        public RankSortOrderReadService(WordManagerContext context) : base(context) { }

        public IQueryable<RankSortOrder> GetAll()
        {
            return _context.RankSortOrders;
        }
    }
}
