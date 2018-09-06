using System.ComponentModel.DataAnnotations;

namespace Wordmanager.Data.Models.Entities
{
    public class Word
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Pronounciation { get; set; }

        public Description Description { get; set; }

    }
}
