using FluentValidation;
using WordManager.Common.DTO;

namespace WordManager.Api.Validators
{
    public class CreateCurriculumValidator : AbstractValidator<CurriculumDTO>
    {

        public CreateCurriculumValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Rank).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Color).NotEmpty();

        }
    }
}
