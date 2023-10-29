using Audote.Server.Domain.Entities;
using MediatR;

namespace Audote.Server.Application.Shared.Queries
{
    public class PaginatedQuery <T> : IRequest<Paged<T>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
