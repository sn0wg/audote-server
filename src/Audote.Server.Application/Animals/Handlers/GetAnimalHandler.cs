using Audote.Server.Application.Animals.Queries;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Animals;
using MediatR;

namespace Audote.Server.Application.Animals.Handlers
{
    public class GetAnimalHandler : IRequestHandler<GetAnimalQuery, Animal?>
    {
        private readonly IAnimalRepository _animalRepository;

        public GetAnimalHandler(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Task<Animal?> Handle(GetAnimalQuery request, CancellationToken cancellationToken)
        {
            return _animalRepository.GetById(request.Id, cancellationToken);
        }
    }
}
