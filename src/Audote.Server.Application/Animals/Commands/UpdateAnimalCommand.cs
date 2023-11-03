using Audote.Server.Domain.Entities;
using Audote.Server.Domain.Enums;
using MediatR;
using OneOf;

namespace Audote.Server.Application.Animals.Commands
{
    public class UpdateAnimalCommand : IRequest<OneOf<bool, Error>>
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
