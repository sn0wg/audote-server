using Audote.Server.Domain.Entities;
using Audote.Server.Domain.Enums;
using MediatR;

namespace Audote.Server.Application.Animals.Queries
{
    public class GetAnimalsQuery: IRequest<Animal[]>
    {
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public bool? Active { get; set; }
        public Kind[] Kinds { get; set; } = Array.Empty<Kind>();
        public Gender[] Genders { get; set; } = Array.Empty<Gender>();
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }
}
