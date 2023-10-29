using Audote.Server.Application.Animals.Commands;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Animals;
using Mapster;
using MediatR;

namespace Audote.Server.Application.Animals.Handlers;

public class UpdateAnimalHandler : IRequestHandler<UpdateAnimalCommand, bool>
{
    private readonly IAnimalRepository _animalRepository;

    public UpdateAnimalHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<bool> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Adapt<Animal>();

        var result = await _animalRepository.Update(entity, cancellationToken);

        return result > 0;
    }
}
