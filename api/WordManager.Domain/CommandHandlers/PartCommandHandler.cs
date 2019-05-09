using System;
using DP.CqsLite;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain
{
    public class PartCommandHandler : ICommandHandler<CreatePartCommand>
    {

        private readonly WordManagerContext _db;

        public PartCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Handle(CreatePartCommand command)
        {

            var change = _db.Parts.Add(new Part
            {
                CategoryId = command.CategoryId,
                CurriculumId = command.CurriculumId,
                ParentPartId = command.ParentPartId
            });

            _db.SaveChanges();
            command.Id = change.Entity.Id;
        }
    }
}
