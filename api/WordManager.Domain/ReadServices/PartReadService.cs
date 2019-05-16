using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.ReadServices
{
    public class PartReadService : ABaseService
    {
        public PartReadService(WordManagerContext context) : base(context) { }

        /// <summary>
        /// Returns all instances of <see cref="Part" /> belonging to the given <see cref="Curriculum"/> id and all their associated navigable entities.
        /// </summary>
        /// <param name="id">The id of the parent <see cref="Curriculum"/></param>
        /// <returns></returns>
        public IQueryable<Part> GetAllByCollectionId(long id)
        {
            var result = _context.Parts
                .Include(x => x.Category)
                .Include(x => x.SubParts)
                .ThenInclude(x => x.Words)
                .Include(x => x.SubParts)
                .ThenInclude(x => x.Category)
                .Include(x => x.Words)
                .Where(x => x.CurriculumId == id)
                .Where(x => x.ParentPartId == null);

            return result;
        }

    }
}
