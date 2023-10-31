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
                .WithErrorCode(nameof(ErrorResource.INVALID_PAGE_SIZE))
                .WithMessage(ErrorResource.INVALID_PAGE_SIZE)
                .GreaterThan(0)
                .WithErrorCode(nameof(ErrorResource.INVALID_PAGE_SIZE))
                .WithMessage(ErrorResource.INVALID_PAGE_SIZE)
                .LessThanOrEqualTo(50)
                .WithErrorCode(nameof(ErrorResource.INVALID_PAGE_SIZE))
                .WithMessage(ErrorResource.INVALID_PAGE_SIZE);

            RuleFor(x => x.Page)
                .NotNull()
                .WithErrorCode(nameof(ErrorResource.INVALID_PAGE))
                .WithMessage(ErrorResource.INVALID_PAGE)
                .GreaterThanOrEqualTo(0)
                .WithErrorCode(nameof(ErrorResource.INVALID_PAGE))
                .WithMessage(ErrorResource.INVALID_PAGE);

            RuleFor(x => x.MinAge)
                .GreaterThan(0)
                .WithErrorCode(nameof(ErrorResource.INVALID_MIN_AGE))
                .WithMessage(ErrorResource.INVALID_MIN_AGE);

            RuleFor(x => x.MaxAge)
                .GreaterThan(0)
                .WithErrorCode(nameof(ErrorResource.INVALID_MAX_AGE))
                .WithMessage(ErrorResource.INVALID_MAX_AGE);

            RuleFor(x => x.State)
                .Length(2, 2)
                .WithErrorCode(nameof(ErrorResource.INVALID_STATE))
                .WithMessage(ErrorResource.INVALID_STATE);

            RuleFor(x => x.City)
                .Length(1, 255)
                .WithErrorCode(nameof(ErrorResource.INVALID_CITY))
                .WithMessage(ErrorResource.INVALID_CITY);
        }
    }
}
