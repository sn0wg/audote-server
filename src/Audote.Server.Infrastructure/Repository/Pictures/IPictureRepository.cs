namespace Audote.Server.Infrastructure.Repository.Pictures
{
    public interface IPictureRepository
    {
        Task<Domain.Entities.Picture?> GetById(int id, CancellationToken cancellationToken);
        Task<int> Save(Domain.Entities.Picture picture, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}
