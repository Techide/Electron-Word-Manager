using DP.CqsLite;
using WordManager.Common.DTO;

namespace WordManager.Domain
{
    public class CreateCurriculumCommand : ICommand
    {
        public CreateCurriculumCommand(CurriculumDTO dTO) => DTO = dTO ?? throw new System.ArgumentNullException(nameof(dTO));

        public CurriculumDTO DTO { get; set; }
    }
}
