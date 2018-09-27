using System;
using System.Linq;
using DP.CqsLite;
using Microsoft.EntityFrameworkCore;
using Wordmanager.Data.Models;
using WordManager.Domain.Extensions;

namespace WordManager.Domain
{
    public class GetPartsFromCollectionIdQueryHandler : IQueryHandler<GetPartsFromCollectionIdQuery, GetPartsFromCollectionIdQueryResult>
    {
        private readonly WordManagerContext _db;

        public GetPartsFromCollectionIdQueryHandler(WordManagerContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public GetPartsFromCollectionIdQueryResult Handle(GetPartsFromCollectionIdQuery query)
        {
            var result = _db.Parts
                .Include(x => x.Category)
                .Include(x => x.SubParts)
                .ThenInclude(x => x.Words)
                .Include(x => x.SubParts)
                .ThenInclude(x => x.Category)
                .Include(x => x.Words)
                .Where(x => x.CurriculumId == query.Id)
                .Where(x => x.ParentPartId == null)
                .Select(PartExtension.ToDTO);

            return new GetPartsFromCollectionIdQueryResult { Data = result };
        }
    }
}
