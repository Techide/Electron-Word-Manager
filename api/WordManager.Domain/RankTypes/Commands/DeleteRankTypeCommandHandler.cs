using DP.CqsLite;
using Wordmanager.Data.Models;

namespace WordManager.Domain.RankTypes.Commands
{
    public class DeleteRankTypeCommandHandler : ICommandHandler<DeleteRankTypeCommand>
    {
        private readonly WordManagerContext _db;

        public DeleteRankTypeCommandHandler(WordManagerContext db)
        {
            _db = db ?? throw new System.ArgumentNullException(nameof(db));
        }

        public void Handle(DeleteRankTypeCommand command)
        {
            var ranktype = _db.RankTypes.Find(command.Id);
            _db.RankTypes.Remove(ranktype);
            _db.SaveChanges();
        }
    }
}
