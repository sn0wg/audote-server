using Audote.Server.Application.Animals.Commands;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Animals;
using Mapster;
using MediatR;

namespace Audote.Server.Application.Animals.Handlers;

public class CreateAnimalHandler : IRequestHandler<CreateAnimalCommand, int>
{
    private readonly IAnimalRepository _animalRepository;
    public CreateAnimalHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public Task<int> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Animal>();

        return _animalRepository.Save(entity, cancellationToken);
    }
}
