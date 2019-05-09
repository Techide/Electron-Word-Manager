using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.ReadServices
{
    public class CurriculumReadService : ABaseService<Curriculum>
    {
        public CurriculumReadService(WordManagerContext context) : base(context) { }

        public IQueryable<Curriculum> GetByRankType(long rankTypeId)
        {
            var q = _context.Curricula
                .Include(x => x.RankType)
                .Where(x => x.RankTypeId == rankTypeId);

            return q;
        }

        public Curriculum GetByRankAndRankTypeName(int rank, string rankTypeName)
        {
            var name = rankTypeName.ToLower();
            var result = _context.Curricula
                .Include(x => x.RankType)
                .Where(x => x.RankType.Name.ToLower().Equals(name))
                .SingleOrDefault(x => x.Rank == rank);

            return result;
        }

    }
}
