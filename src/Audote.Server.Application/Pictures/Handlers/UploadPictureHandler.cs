using Audote.Server.Application.Pictures.Commands;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Pictures;
using Audote.Server.Infrastructure.Storages;
using MediatR;

namespace Audote.Server.Application.Pictures.Handlers
{
    public class UploadPictureHandler : IRequestHandler<UploadPictureCommand, int>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IStorage _storage;

        public UploadPictureHandler(IStorage storage, IPictureRepository pictureRepository)
        {
            _storage = storage;
            _pictureRepository = pictureRepository;
        }

        public async Task<int> Handle(UploadPictureCommand request, CancellationToken cancellationToken)
        {
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
