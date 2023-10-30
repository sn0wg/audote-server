using Audote.Server.Application.Animals.Queries;
using Audote.Server.Application.Extensions;
using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Animals;
using Audote.Server.Infrastructure.Repository.Animals.Filters;
using FluentValidation;
using Mapster;
using MediatR;
using OneOf;

namespace Audote.Server.Application.Animals.Handlers
{
    public class GetAnimalsHandler : IRequestHandler<GetAnimalsQuery, OneOf<Paged<Animal[]>, Error>>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IValidator<GetAnimalsQuery> _validator;

        public GetAnimalsHandler(IAnimalRepository animalRepository, IValidator<GetAnimalsQuery> validator)
        {
            _animalRepository = animalRepository;
            _validator = validator;
        }
        public async Task<OneOf<Paged<Animal[]>, Error>> Handle(GetAnimalsQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return validationResult.ToError();

            var query = request.Adapt<AnimalFilter>();

            return await _animalRepository.Get(query, cancellationToken);
        }
    }
}
