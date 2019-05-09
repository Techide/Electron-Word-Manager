using System.ComponentModel.DataAnnotations;

namespace Wordmanager.Data.Entities
{
    public class Word : IEntity
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Pronounciation { get; set; }

        public Description Description { get; set; }

    }
}
