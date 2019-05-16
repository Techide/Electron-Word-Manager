using System.Collections.Generic;

namespace WordManager.Common.DTO
{
    public class PartModel : IModel
    {

        public long Id { get; set; }

        public string Name { get; set; }

        public long CurriculumId { get; set; }

        public long CategoryId { get; set; }

        public long? ParentPartId { get; set; }

        public IEnumerable<WordModel> Words { get; set; }

        public IEnumerable<PartModel> SubParts { get; set; }
    }
}
