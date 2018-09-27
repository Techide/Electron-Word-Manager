using System.Linq;
using DP.CqsLite;
using Wordmanager.Data.Models;
using WordManager.Domain.Extensions;

namespace WordManager.Domain
{
    public class GetAllRankSortOrdersQueryHandler : IQueryHandler<GetAllRankSortOrdersQuery, GetAllRankSortOrdersQueryResult>
    {
        private readonly WordManagerContext _db;

        public GetAllRankSortOrdersQueryHandler(WordManagerContext db)
        {
            _db = db ?? throw new System.ArgumentNullException(nameof(db));
        }

        public GetAllRankSortOrdersQueryResult Handle(GetAllRankSortOrdersQuery query)
        {
            var result = _db.RankSortOrders.ToList().Select(RankSortOrderExtensions.ToDTO);
            return new GetAllRankSortOrdersQueryResult(result);
        }
    }
}
