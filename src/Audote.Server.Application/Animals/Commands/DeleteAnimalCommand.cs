using MediatR;

namespace Audote.Server.Application.Animals.Commands
{
    public class DeleteAnimalCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
