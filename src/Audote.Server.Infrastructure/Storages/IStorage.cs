namespace Audote.Server.Infrastructure.Storages;

public interface IStorage
{
    Task<string> Save(Stream content, CancellationToken cancellationToken);
    Task<bool> Delete(string path, CancellationToken cancellationToken);
    Task<Stream?> Open(string path, CancellationToken cancellationToken);
}
