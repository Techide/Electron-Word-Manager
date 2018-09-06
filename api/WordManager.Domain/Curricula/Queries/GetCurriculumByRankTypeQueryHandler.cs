using System.Linq;
using DP.CqsLite;
using Wordmanager.Data.Models;
using WordManager.Common.DTO;

namespace WordManager.Domain.Curricula.Queries
{
    public class GetCurriculumByRankTypeQueryHandler : IQueryHandler<GetCurriculumByRankTypeQuery, GetCurriculumByRankTypeQueryResult>
    {
        private readonly WordManagerContext _db;

        public GetCurriculumByRankTypeQueryHandler(WordManagerContext db)
        {
            _db = db ?? throw new System.ArgumentNullException(nameof(db));
        }

        public GetCurriculumByRankTypeQueryResult Handle(GetCurriculumByRankTypeQuery query)
        {
            var result = _db.Curricula.Where(x => x.RankTypeId == query.RankTypeId)
                .Select(x => new CurriculumDTO
                {
                    Id = x.Id,
                    Color = x.Color,
                    Rank = x.Rank,
                    RankType = x.RankType.Name
                });
            return new GetCurriculumByRankTypeQueryResult(result);
        }
    }
}
