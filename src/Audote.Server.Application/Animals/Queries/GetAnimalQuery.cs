using Audote.Server.Domain.Entities;
using MediatR;

namespace Audote.Server.Application.Animals.Queries
{
    public class GetAnimalQuery : IRequest<Animal?>
    {
        public int Id { get; set; }
    }
}
