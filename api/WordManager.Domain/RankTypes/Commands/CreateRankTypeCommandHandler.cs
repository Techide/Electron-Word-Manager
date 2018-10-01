using System;
using DP.CqsLite;
using Wordmanager.Data.Models;
using Wordmanager.Data.Models.Entities;

namespace WordManager.Domain
{
    public class CreateRankTypeCommandHandler : ICommandHandler<CreateRankTypeCommand>
    {

        private readonly WordManagerContext _db;

        public CreateRankTypeCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Handle(CreateRankTypeCommand command)
        {
            var newRankType = _db.RankTypes.Add(new RankType
            {
                Name = command.DTO.Name,
                SortOrderId = command.DTO.SortOrderId
            });

            _db.SaveChanges();
            command.DTO.Id = newRankType.Entity.Id;
        }
    }
}
