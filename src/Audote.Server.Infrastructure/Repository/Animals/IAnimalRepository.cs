using Audote.Server.Infrastructure.Repository.Animals.Filters;

namespace Audote.Server.Infrastructure.Repository.Animals
{
    public interface IAnimalRepository
    {
        Task<Domain.Entities.Animal[]> Get(AnimalFilter animalFilter, CancellationToken cancellationToken);
        Task<Domain.Entities.Animal?> GetById(int animalId, CancellationToken cancellationToken);
        Task<int> Save(Domain.Entities.Animal animal, CancellationToken cancellationToken);
        Task<int> Update(Domain.Entities.Animal animal, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}
