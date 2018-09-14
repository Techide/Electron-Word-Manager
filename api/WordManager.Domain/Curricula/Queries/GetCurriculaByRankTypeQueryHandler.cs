using System.Linq;
using DP.CqsLite;
using Microsoft.EntityFrameworkCore;
using Wordmanager.Data.Models;
using WordManager.Domain.Extensions;

namespace WordManager.Domain
{
    public class GetCurriculaByRankTypeQueryHandler : IQueryHandler<GetCurriculaByRankTypeQuery, GetCurriculaByRankTypeQueryResult>
    {
        private readonly WordManagerContext _db;

        public GetCurriculaByRankTypeQueryHandler(WordManagerContext db)
        {
            _db = db ?? throw new System.ArgumentNullException(nameof(db));
        }

        public GetCurriculaByRankTypeQueryResult Handle(GetCurriculaByRankTypeQuery query)
        {
            var q = _db.Curricula
                .Include(x => x.RankType)
                .Where(x => x.RankTypeId == query.RankTypeId);

            // Workaround to eagerly load included navigation properties before changing the query with select and thus ignoring the includes;
            // See: https://docs.microsoft.com/en-us/ef/core/querying/related-data#ignored-includes
            var hack = q.ToList();

            return new GetCurriculaByRankTypeQueryResult(q.Select(CurriculumExtensions.ToDTOExpression));
        }
    }
}
