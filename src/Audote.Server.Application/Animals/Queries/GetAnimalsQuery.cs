using Audote.Server.Domain.Entities;
using Audote.Server.Domain.Enums;
using MediatR;
using OneOf;

namespace Audote.Server.Application.Animals.Queries
{
    public class GetAnimalsQuery: IRequest<OneOf<Paged<Animal[]>, Error>>
    {
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public bool? Active { get; set; }
        public Kind[] Kinds { get; set; } = Array.Empty<Kind>();
        public Gender[] Genders { get; set; } = Array.Empty<Gender>();
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
