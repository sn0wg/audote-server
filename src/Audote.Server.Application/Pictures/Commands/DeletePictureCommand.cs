using MediatR;

namespace Audote.Server.Application.Pictures.Commands
{
    public class DeletePictureCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
