using Audote.Server.Domain.Entities;
using MediatR;
using OneOf;

namespace Audote.Server.Application.Pictures.Commands
{
    public class UploadPictureCommand : IRequest<OneOf<int, Error>>
    {
        public int AnimalId { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public Stream PictureStream { get; set; }
    }
}
