using System.Linq;
using DP.CqsLite;
using Wordmanager.Data.Models;
using WordManager.Domain.Extensions;

namespace WordManager.Domain.RankTypes
{
    public class GetAllRankTypesQueryHandler : IQueryHandler<GetAllRankTypesQuery, GetAllRankTypesQueryResult>
    {
        private readonly WordManagerContext _db;

        public GetAllRankTypesQueryHandler(WordManagerContext db)
        {
            _db = db;
        }

        public GetAllRankTypesQueryResult Handle(GetAllRankTypesQuery query)
        {
            var result = new GetAllRankTypesQueryResult { RankTypes = _db.RankTypes.Select(RankTypeExtensions.ToDTO) };

            return result;
        }
    }
}
