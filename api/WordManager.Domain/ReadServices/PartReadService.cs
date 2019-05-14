using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.ReadServices
{
    public class PartReadService : ABaseService<Part>, IReadService<Part>
    {
        public PartReadService(WordManagerContext context) : base(context) { }

        public IQueryable<Part> GetManyFromCollectionId(long id)
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
