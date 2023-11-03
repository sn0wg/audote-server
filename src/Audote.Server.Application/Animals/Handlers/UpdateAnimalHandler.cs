using Audote.Server.Application.Animals.Commands;
using Audote.Server.Application.Extensions;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Animals;
using FluentValidation;
using Mapster;
using MediatR;
using OneOf;

namespace Audote.Server.Application.Animals.Handlers;

public class UpdateAnimalHandler : IRequestHandler<UpdateAnimalCommand, OneOf<bool, Error>>
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IValidator<UpdateAnimalCommand> _validator;

    public UpdateAnimalHandler(IAnimalRepository animalRepository, IValidator<UpdateAnimalCommand> validator)
    {
        _animalRepository = animalRepository;
        _validator = validator;
    }

    public async Task<OneOf<bool, Error>> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return validationResult.ToError();

        var entity = request.Adapt<Animal>();

        var result = await _animalRepository.Update(entity, cancellationToken);

        return result > 0;
    }
}
