using Audote.Server.Application.Pictures.Queries;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Pictures;
using Audote.Server.Infrastructure.Storages;
using MediatR;

namespace Audote.Server.Application.Pictures.Handlers
{
    public class GetPictureHandler : IRequestHandler<GetPictureQuery, Picture?>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IStorage _storage;

        public GetPictureHandler(IStorage storage, IPictureRepository pictureRepository)
        {
            _storage = storage;
            _pictureRepository = pictureRepository;
        }
        public async Task<Picture?> Handle(GetPictureQuery request, CancellationToken cancellationToken)
        {
            var picture = await _pictureRepository.GetById(request.Id, cancellationToken);

            if (picture == null)
                return null;

            picture.Data = await _storage.Open(picture.Path, cancellationToken);

            return picture;
        }
    }
}
