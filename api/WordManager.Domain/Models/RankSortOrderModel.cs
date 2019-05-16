namespace WordManager.Common.DTO
{
    public class RankSortOrderModel : IModel
    {
        public long Id { get; set; }

        public string Direction { get; set; }

        public int Value { get; set; }

    }
}
