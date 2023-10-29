using Audote.Server.Domain.Enums;
using MediatR;

namespace Audote.Server.Application.Animals.Commands
{
    public class UpdateAnimalCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Kind Kind { get; set; }
        public Gender Gender { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
