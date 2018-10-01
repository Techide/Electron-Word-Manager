using DP.CqsLite;
using Wordmanager.Data.Models;

namespace WordManager.Domain
{
    public class UpdateRankTypeCommandHandler : ICommandHandler<UpdateRankTypeCommand>
    {
        private readonly WordManagerContext _db;

        public UpdateRankTypeCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new System.ArgumentNullException(nameof(db));
        }

        public void Handle(UpdateRankTypeCommand command)
        {
            var item = _db.RankTypes.Find(command.RankType.Id);
            item.Name = command.RankType.Name;
            item.SortOrderId = command.RankType.SortOrderId;
            _db.SaveChanges();
        }
    }
}
