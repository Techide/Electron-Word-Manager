using System;
using System.Linq;
using DP.CqsLite;
using Wordmanager.Data;

namespace WordManager.Domain.Commands
{
    public class CurriculumCommandHandler : ICommandHandler<CreateCurriculumCommand>, ICommandHandler<UpdateCurriculumCommand>, ICommandHandler<DeleteCurriculumCommand>
    {

        private readonly WordManagerContext _db;

        public CurriculumCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Handle(CreateCurriculumCommand command)
        {
            var rankType = _db.RankTypes.Single(x => x.Name.ToLower() == command.RankType.ToLower());
            var change = _db.Curricula.Add(new Wordmanager.Data.Entities.Curriculum
            {
                Color = command.Color,
                Rank = command.Rank,
                RankTypeId = rankType.Id
            });
            _db.SaveChanges();
            command.Id = change.Entity.Id;
        }

        public void Handle(DeleteCurriculumCommand command)
        {
            var curriculum = _db.Curricula.Find(command.Id);
            _db.Curricula.Remove(curriculum);
            _db.SaveChanges();
        }

        public void Handle(UpdateCurriculumCommand command)
        {
            var existing = _db.Curricula.Find(command.Id);
            existing.Rank = command.Rank;
            existing.Color = command.Color;
            _db.SaveChanges();
        }
    }
}
