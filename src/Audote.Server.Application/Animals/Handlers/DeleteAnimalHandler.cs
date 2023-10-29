using Audote.Server.Application.Animals.Commands;
using Audote.Server.Infrastructure.Repository.Animals;
using MediatR;

namespace Audote.Server.Application.Animals.Handlers;

public class DeleteAnimalHandler : IRequestHandler<DeleteAnimalCommand, bool>
{
    private readonly IAnimalRepository _animalRepository;

    public DeleteAnimalHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<bool> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
    {
        var result = await _animalRepository.Delete(request.Id, cancellationToken);

        return result > 0;
    }
}
