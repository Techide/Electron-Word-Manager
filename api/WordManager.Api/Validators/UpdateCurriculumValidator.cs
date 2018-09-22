using FluentValidation;
using WordManager.Common.DTO;

namespace WordManager.Api.Validators
{
    public class UpdateCurriculumValidator : AbstractValidator<UpdateCurriculumDTO>
    {
        public UpdateCurriculumValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Rank)
                .NotEmpty().WithName("Niveau")
                .GreaterThan(0).WithName("Niveau");
            RuleFor(x => x.Color).NotEmpty().WithName("Bælte");
        }
    }
}
