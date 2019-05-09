using DP.CqsLite;

namespace WordManager.Domain
{
    public class UpdateRankTypeCommand : ICommand
    {
        public UpdateRankTypeCommand(long id, string name, long sortOrderId)
        {
            Id = id;
            Name = name;
            SortOrderId = sortOrderId;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public long SortOrderId { get; set; }

    }
}
