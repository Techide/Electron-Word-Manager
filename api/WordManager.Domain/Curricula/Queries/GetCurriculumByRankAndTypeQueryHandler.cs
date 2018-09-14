using System;
using System.Linq;
using DP.CqsLite;
using Microsoft.EntityFrameworkCore;
using Wordmanager.Data.Models;
using WordManager.Domain.Extensions;

namespace WordManager.Domain
{
    public class GetCurriculumByRankAndTypeQueryHandler : IQueryHandler<GetCurriculumByRankAndTypeQuery, GetCurriculumByRankAndTypeQueryResult>
    {
        private readonly WordManagerContext _db;

        public GetCurriculumByRankAndTypeQueryHandler(WordManagerContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public GetCurriculumByRankAndTypeQueryResult Handle(GetCurriculumByRankAndTypeQuery query)
        {
            var result = _db.Curricula
                .Include(x => x.RankType)
                .Where(x => x.RankType.Name.ToLower() == query.RankType.ToLower())
                .SingleOrDefault(x => x.Rank == query.Rank)?.ToDTO();
            return new GetCurriculumByRankAndTypeQueryResult(result);
        }
    }
}
