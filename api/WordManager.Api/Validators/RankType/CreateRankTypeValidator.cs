using FluentValidation;
using WordManager.Common.DTO;

namespace WordManager.Api.Validators
{
    public class CreateRankTypeValidator : AbstractValidator<RankTypeModel>
    {
        public CreateRankTypeValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name).NotEmpty().WithName("Graduering");
            RuleFor(x => x.SortOrderId).NotEmpty().WithName("Rækkefølge");

        }
    }
}
