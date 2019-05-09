using System.Collections.Generic;

namespace Wordmanager.Data.Entities
{
    public class Part : IEntity
    {
        public long Id { get; set; }

        public long CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }

        public long CategoryId { get; set; }
        public Category Category { get; set; }

        public long? ParentPartId { get; set; }
        public Part ParentPart { get; set; }

        public IEnumerable<Part> SubParts { get; set; }

        public IEnumerable<Word> Words { get; set; }
    }
}
