using DP.CqsLite;
using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class CreatePartCommand : ICommand
    {
        public PartDTO Part { get; set; }

        public CreatePartCommand(PartDTO part)
        {
            Part = part ?? throw new System.ArgumentNullException(nameof(part));
        }
    }
}
