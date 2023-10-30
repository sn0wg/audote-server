using Audote.Server.Application.Animals.Queries;
using Audote.Server.Application.Resources;
using FluentValidation;

namespace Audote.Server.Application.Animals.Validators
{
    public class GetAnimalsQueryValidator : AbstractValidator<GetAnimalsQuery>
    {
        public GetAnimalsQueryValidator()
        {
            RuleFor(x => x.PageSize)
                .NotNull()
                .GreaterThan(0)
                .LessThanOrEqualTo(50)
                .WithErrorCode(nameof(ErrorResource.INVALID_PAGE_SIZE))
                .WithMessage(ErrorResource.INVALID_PAGE_SIZE);

            RuleFor(x => x.Page)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithErrorCode(nameof(ErrorResource.INVALID_PAGE))
                .WithMessage(ErrorResource.INVALID_PAGE);
        }
    }
}
