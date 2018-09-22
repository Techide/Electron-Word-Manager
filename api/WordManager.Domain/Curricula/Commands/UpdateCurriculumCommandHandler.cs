using DP.CqsLite;
using Wordmanager.Data.Models;

namespace WordManager.Domain.Curricula.Commands
{
    public class UpdateCurriculumCommandHandler : ICommandHandler<UpdateCurriculumCommand>
    {
        private readonly WordManagerContext _db;

        public UpdateCurriculumCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new System.ArgumentNullException(nameof(db));
        }

        public void Handle(UpdateCurriculumCommand command)
        {
            var existing = _db.Curricula.Find(command.DTO.Id);
            existing.Rank = command.DTO.Rank;
            existing.Color = command.DTO.Color;
            _db.SaveChanges();
        }
    }
}
