using Audote.Server.Domain.Entities;
using MediatR;

namespace Audote.Server.Application.Pictures.Queries
{
    public class GetPictureQuery : IRequest<Picture?>
    {
        public int Id { get; set; }
    }
}
