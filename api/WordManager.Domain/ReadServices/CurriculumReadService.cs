using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.ReadServices
{
    public class CurriculumReadService : ABaseService
    {
        public CurriculumReadService(WordManagerContext context) : base(context) { }

        /// <summary>
        /// Returns a <see cref="Curriculum"/> from the database context filtered by the provided parameter.
        /// </summary>
        /// <param name="rankTypeId">The id of an existing <see cref="RankType"/></param>
        /// <returns></returns>
        public IQueryable<Curriculum> Get(long rankTypeId)
        {
            var q = _context.Curricula
                .Include(x => x.RankType)
                .Where(x => x.RankTypeId == rankTypeId);

            return q;
        }

        /// <summary>
        /// Returns a <see cref="Curriculum"/> from the database context filtered by the provided parameters.
        /// </summary>
        /// <param name="rank">The rank of the desired <see cref="Curriculum"/></param>
        /// <param name="rankTypeName">The name of the associated <see cref="RankType"/></param>
        /// <returns></returns>
        public Curriculum Get(int rank, string rankTypeName)
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
