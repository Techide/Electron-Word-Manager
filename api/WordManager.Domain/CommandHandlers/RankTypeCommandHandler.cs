using System;
using DP.CqsLite;
using Wordmanager.Data;
using Wordmanager.Data.Entities;

namespace WordManager.Domain.Commands
{
    public class RankTypeCommandHandler : ICommandHandler<CreateRankTypeCommand>, ICommandHandler<DeleteRankTypeCommand>, ICommandHandler<UpdateRankTypeCommand>
    {

        private readonly WordManagerContext _db;

        public RankTypeCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Handle(CreateRankTypeCommand command)
        {
            var newRankType = _db.RankTypes.Add(new RankType
            {
                Name = command.Name,
                SortOrderId = command.SortOrderId
            });

            _db.SaveChanges();
            command.Id = newRankType.Entity.Id;
        }

        public void Handle(DeleteRankTypeCommand command)
        {
            var ranktype = _db.RankTypes.Find(command.Id);
            _db.RankTypes.Remove(ranktype);
            _db.SaveChanges();
        }

        public void Handle(UpdateRankTypeCommand command)
        {
            var item = _db.RankTypes.Find(command.Id);
            item.Name = command.Name;
            item.SortOrderId = command.SortOrderId;
            _db.SaveChanges();
        }
    }
}
