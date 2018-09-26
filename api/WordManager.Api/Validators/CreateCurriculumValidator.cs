using FluentValidation;
using WordManager.Common.DTO;

namespace WordManager.Api.Validators
{
    public class CreateCurriculumValidator : AbstractValidator<CurriculumDTO>
    {

        public CreateCurriculumValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Rank)
                .GreaterThan(0).WithName("Niveau")
                .NotEmpty().WithName("Niveau");
            RuleFor(x => x.Color).NotEmpty().WithName("Bælte");
        }
    }
}
