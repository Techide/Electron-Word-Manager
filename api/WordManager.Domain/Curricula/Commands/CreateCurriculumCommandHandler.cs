using System;
using System.Linq;
using DP.CqsLite;
using Wordmanager.Data.Models;

namespace WordManager.Domain.Curricula.Commands
{
    public class CreateCurriculumCommandHandler : ICommandHandler<CreateCurriculumCommand>
    {

        private readonly WordManagerContext _db;

        public CreateCurriculumCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Handle(CreateCurriculumCommand command)
        {
            var rankType = _db.RankTypes.Where(x => x.Name.ToLower() == command.DTO.RankType.ToLower()).Single();

            var created = _db.Curricula.Add(new Wordmanager.Data.Models.Entities.Curriculum
            {
                Color = command.DTO.Color,
                Rank = command.DTO.Rank,
                RankTypeId = rankType.Id
            });
            _db.SaveChanges();
            command.DTO.Id = created.Entity.Id;
        }
    }
}
