using Audote.Server.Application.Animals.Commands;
using Audote.Server.Application.Resources;
using FluentValidation;

namespace Audote.Server.Application.Animals.Validators
{
    public class UpdateAnimalCommandValidator : AbstractValidator<UpdateAnimalCommand>
    {
        public UpdateAnimalCommandValidator()
        {
            RuleFor(x => x.Name)
                .Length(1, 255)
                .WithErrorCode(nameof(ErrorResource.INVALID_NAME))
                .WithMessage(ErrorResource.INVALID_NAME);

            RuleFor(x => x.Description)
                .Length(1, 999)
                .WithErrorCode(nameof(ErrorResource.INVALID_DESCRIPTION))
                .WithMessage(ErrorResource.INVALID_DESCRIPTION);

            RuleFor(x => x.Age)
                .GreaterThan(0)
                .WithErrorCode(nameof(ErrorResource.INVALID_MIN_AGE))
                .WithMessage(ErrorResource.INVALID_MIN_AGE);

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
