namespace Wordmanager.Data.Entities
{
    public class RankSortOrder : IEntity
    {
        public long Id { get; set; }

        public string Direction { get; set; }

        public int Value { get; set; }
    }
}
