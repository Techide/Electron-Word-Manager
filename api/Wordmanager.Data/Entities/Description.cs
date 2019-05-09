namespace Wordmanager.Data.Entities
{
    public class Description : IEntity
    {
        public long Id { get; set; }

        public long WordId { get; set; }
        public Word Word { get; set; }
    }
}
