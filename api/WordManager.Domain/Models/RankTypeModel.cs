namespace WordManager.Common.DTO
{
    public class RankTypeModel : IModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long SortOrderId { get; set; }

    }
}
