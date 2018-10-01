using FluentValidation;
using WordManager.Common.DTO;

namespace WordManager.Api.Validators
{
    public class UpdateRankTypeValidator : AbstractValidator<RankTypeDTO>
    {
        public UpdateRankTypeValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).NotEmpty().WithName("Id");
            RuleFor(x => x.Name).NotEmpty().WithName("Graduering");
            RuleFor(x => x.SortOrderId).NotEmpty().WithName("Rækkefølge");
        }
    }
}
