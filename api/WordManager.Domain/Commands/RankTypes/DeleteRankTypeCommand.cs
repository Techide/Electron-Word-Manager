using DP.CqsLite;

namespace WordManager.Domain
{
    public class DeleteRankTypeCommand : ICommand
    {
        public DeleteRankTypeCommand(long id) => Id = id;

        public long Id { get; }
    }
}
