using DP.CqsLite;

namespace WordManager.Domain
{
    public class CreatePartCommand : ICommand
    {
        public long Id { get; set; }

        public long CurriculumId { get; set; }

        public long CategoryId { get; set; }

        public long? ParentPartId { get; set; }

        public CreatePartCommand(long id, long curriculumId, long categoryId, long? parentPartId)
        {
            Id = id;
            CurriculumId = curriculumId;
            CategoryId = categoryId;
            ParentPartId = parentPartId;
        }
    }
}
