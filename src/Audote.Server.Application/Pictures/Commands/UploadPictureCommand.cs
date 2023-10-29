using MediatR;

namespace Audote.Server.Application.Pictures.Commands
{
    public class UploadPictureCommand : IRequest<int>
    {
        public int AnimalId { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public Stream PictureStream { get; set; }
    }
}
