using Audote.Server.Application.Pictures.Commands;
using Audote.Server.Application.Resources;
using FluentValidation;

namespace Audote.Server.Application.Pictures.Validators
{
    public class UploadPictureCommandValidator : AbstractValidator<UploadPictureCommand>
    {
        public UploadPictureCommandValidator()
        {
            RuleFor(x => x.Description)
                .Length(1, 999)
                .WithErrorCode(nameof(ErrorResource.INVALID_DESCRIPTION))
                .WithMessage(ErrorResource.INVALID_DESCRIPTION);

            RuleFor(x => x.ContentType)
                .Length(1, 100)
                .WithErrorCode(nameof(ErrorResource.INVALID_CONTENT_TYPE))
                .WithMessage(ErrorResource.INVALID_CONTENT_TYPE);

            RuleFor(x => x.PictureStream)
                .NotNull()
                .WithErrorCode(nameof(ErrorResource.INVALID_STREAM))
                .WithMessage(ErrorResource.INVALID_STREAM);
        }
    }
}
