using System;
using DP.CqsLite;
using Wordmanager.Data.Models;

namespace WordManager.Domain
{
    public class DeleteCurriculumCommandHandler : ICommandHandler<DeleteCurriculumCommand>
    {
        private readonly WordManagerContext _db;

        public DeleteCurriculumCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Handle(DeleteCurriculumCommand command)
        {
            var curriculum = _db.Curricula.Find(command.Id);

            _db.Curricula.Remove(curriculum);

            _db.SaveChanges();
        }
    }
}
