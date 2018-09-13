using System.Linq;
using DP.CqsLite;
using Wordmanager.Data.Models;
using WordManager.Domain.Extensions;

namespace WordManager.Domain
{
    public class GetRankTypeByNameQueryHandler : IQueryHandler<GetRankTypeByNameQuery, GetRankTypeByNameQueryResult>
    {
        private readonly WordManagerContext _db;

        public GetRankTypeByNameQueryHandler(WordManagerContext db)
        {
            _db = db;
        }

        public GetRankTypeByNameQueryResult Handle(GetRankTypeByNameQuery query)
        {
            var result = _db.RankTypes.Where(x => x.Name.ToLower().Equals(query.Name.ToLower())).Select(RankTypeExtensions.ToDTO).SingleOrDefault();

            return new GetRankTypeByNameQueryResult(result);
        }
    }
}
