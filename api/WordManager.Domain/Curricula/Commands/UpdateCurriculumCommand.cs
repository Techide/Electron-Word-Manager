using DP.CqsLite;
using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class UpdateCurriculumCommand : ICommand
    {
        public UpdateCurriculumCommand(UpdateCurriculumDTO dTO)
        {
            DTO = dTO;
        }

        public CurriculumDTO DTO { get; }
    }
}
