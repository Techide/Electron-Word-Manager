using System.Collections.Generic;
using System.Linq;

namespace WordManager.Common.DTO
{
    public class PartDTO
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public long CurriculumId { get; set; }

        public long CategoryId { get; set; }

        public long? ParentPartId { get; set; }

        public IEnumerable<WordDTO> Words { get; set; }

        public IEnumerable<PartDTO> SubParts { get; set; }
    }
}
