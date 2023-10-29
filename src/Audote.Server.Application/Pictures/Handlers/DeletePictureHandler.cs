using Audote.Server.Application.Pictures.Commands;
using Audote.Server.Infrastructure.Repository.Pictures;
using Audote.Server.Infrastructure.Storages;
using MediatR;

namespace Audote.Server.Application.Pictures.Handlers
{
    public class DeletePictureHandler : IRequestHandler<DeletePictureCommand, bool>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IStorage _storage;

        public DeletePictureHandler(IStorage storage, IPictureRepository pictureRepository)
        {
            _storage = storage;
            _pictureRepository = pictureRepository;
        }

        public async Task<bool> Handle(DeletePictureCommand request, CancellationToken cancellationToken)
        {
            var picture = await _pictureRepository.GetById(request.Id, cancellationToken);

            if (picture == null)
                return false;

            await _pictureRepository.Delete(request.Id, cancellationToken);

            await _storage.Delete(picture.Path, cancellationToken);

            return true;
        }
    }
}
