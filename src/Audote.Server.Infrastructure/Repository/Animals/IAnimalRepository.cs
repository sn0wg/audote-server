using Audote.Server.Domain.Entities;
using Audote.Server.Infrastructure.Repository.Animals.Filters;

namespace Audote.Server.Infrastructure.Repository.Animals
{
    public interface IAnimalRepository
    {
        Task<Paged<Animal[]>> Get(AnimalFilter animalFilter, CancellationToken cancellationToken);
        Task<Animal?> GetById(int animalId, CancellationToken cancellationToken);
        Task<int> Save(Animal animal, CancellationToken cancellationToken);
        Task<int> Update(Animal animal, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}
