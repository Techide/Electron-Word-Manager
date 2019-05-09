using DP.CqsLite;

namespace WordManager.Domain
{
    public class DeleteCurriculumCommand : ICommand
    {
        public DeleteCurriculumCommand(ulong id)
        {
            Id = (long)id;
        }

        public long Id { get; }
    }
}
