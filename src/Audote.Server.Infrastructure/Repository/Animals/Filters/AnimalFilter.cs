using Audote.Server.Domain.Enums;

namespace Audote.Server.Infrastructure.Repository.Animals.Filters
{
    public class AnimalFilter
    {
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public int? Active { get; set; }
        public Kind[] Kinds { get; set; } = Array.Empty<Kind>();
        public Gender[] Genders { get; set; } = Array.Empty<Gender>();
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
