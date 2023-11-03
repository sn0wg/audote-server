using Audote.Server.Application.Extensions;
using Audote.Server.Application.Pictures.Commands;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Pictures;
using Audote.Server.Infrastructure.Storages;
using FluentValidation;
using MediatR;
using OneOf;

namespace Audote.Server.Application.Pictures.Handlers
{
    public class UploadPictureHandler : IRequestHandler<UploadPictureCommand, OneOf<int, Error>>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IStorage _storage;
        private readonly IValidator<UploadPictureCommand> _validator;

        public UploadPictureHandler(IStorage storage, IPictureRepository pictureRepository, IValidator<UploadPictureCommand> validator)
        {
            _storage = storage;
            _pictureRepository = pictureRepository;
            _validator = validator;
        }

        public async Task<OneOf<int, Error>> Handle(UploadPictureCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return validationResult.ToError();

            var path = await _storage.Save(request.PictureStream, cancellationToken);

            var picture = new Picture
            {
                Description = request.Description,
                Path = path,
                ContentType = request.ContentType,
                AnimalId = request.AnimalId,
            };

            return await _pictureRepository.Save(picture, cancellationToken);
        }
    }
}
