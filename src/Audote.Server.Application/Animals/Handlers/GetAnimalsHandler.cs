using Audote.Server.Application.Animals.Queries;
using Audote.Server.Application.Shared.Queries;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Animals;
using Audote.Server.Infrastructure.Repository.Animals.Filters;
using Mapster;
using MediatR;

namespace Audote.Server.Application.Animals.Handlers
{
    public class GetAnimalsHandler : IRequestHandler<GetAnimalsQuery, Paged<Animal[]>>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAnimalsHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public Task<Paged<Animal[]>> Handle(GetAnimalsQuery request, CancellationToken cancellationToken)
        {
            var query = request.Adapt<AnimalFilter>();

            return _animalRepository.Get(query, cancellationToken);
        }
    }
}
