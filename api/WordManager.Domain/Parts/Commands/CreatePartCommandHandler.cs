using System;
using DP.CqsLite;
using Wordmanager.Data.Models;
using Wordmanager.Data.Models.Entities;

namespace WordManager.Domain
{
    public class CreatePartCommandHandler : ICommandHandler<CreatePartCommand>
    {

        private readonly WordManagerContext _db;

        public CreatePartCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Handle(CreatePartCommand command)
        {

            var change = _db.Parts.Add(new Part
            {
                CategoryId = command.Part.CategoryId,
                CurriculumId = command.Part.CurriculumId,
                ParentPartId = command.Part.ParentPartId
            });

            _db.SaveChanges();
            command.Part.Id = change.Entity.Id;
        }
    }
}
