using FluentValidation;
using FluentValidation.Results;
using WordManager.Common.DTO;

namespace WordManager.Api.Validators
{
    public class UpdateCurriculumValidator : AbstractValidator<UpdateCurriculumDTO>
    {
        public UpdateCurriculumValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).NotEmpty().WithName("Id");
            RuleFor(x => x.Rank)
                .NotEmpty().WithName("Niveau")
                .GreaterThan(0).WithName("Niveau");
            RuleFor(x => x.Color).NotEmpty().WithName("Bælte");

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Color.Equals(x.OriginalColor) && x.Rank == x.OriginalRank)
                {
                    context.AddFailure(new ValidationFailure("No_Changes", "Der er ingen ændringer at opdatere."));
                };
            });
        }
    }
}
