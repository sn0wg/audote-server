using Audote.Server.Application.Animals.Commands;
using Audote.Server.Application.Extensions;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Animals;
using FluentValidation;
using Mapster;
using MediatR;
using OneOf;

namespace Audote.Server.Application.Animals.Handlers;

public class CreateAnimalHandler : IRequestHandler<CreateAnimalCommand, OneOf<int, Error>>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IValidator<CreateAnimalCommand> _validator;

    public CreateAnimalHandler(IAnimalRepository animalRepository, IValidator<CreateAnimalCommand> validator)
    {
        _animalRepository = animalRepository;
        _validator = validator;
    }

    public async Task<OneOf<int, Error>> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return validationResult.ToError();

        var entity = request.Adapt<Animal>();

        return await _animalRepository.Save(entity, cancellationToken);
    }
}
