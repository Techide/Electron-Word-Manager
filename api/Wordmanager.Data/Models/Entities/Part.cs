using System.Collections.Generic;

namespace Wordmanager.Data.Models.Entities
{
    public class Part
    {
        public long Id { get; set; }

        public long CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }

        public long NameId { get; set; }
        public Category Name { get; set; }

        public long? ParentPartId { get; set; }
        public Part ParentPart { get; set; }

        public ICollection<Part> SubParts { get; set; }

        public ICollection<Word> Words { get; set; }
    }
}
