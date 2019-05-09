using DP.CqsLite;

namespace WordManager.Domain
{
    public class CreateRankTypeCommand : ICommand
    {
        public CreateRankTypeCommand(long id, string name, long sortOrderId)
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
