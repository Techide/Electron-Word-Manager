namespace Wordmanager.Data.Models.Entities
{
    public class Description
    {
        public long Id { get; set; }

        public long WordId { get; set; }
        public Word Word { get; set; }

    }
}
