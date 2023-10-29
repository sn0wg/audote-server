using Audote.Server.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace Audote.Server.Infrastructure.Storages;

internal class FileStorage : IStorage
{
    private readonly string _rootFolder = string.Empty;

    public FileStorage(IOptions<StorageSettings> settings)
    {
        _rootFolder = settings.Value.BasePath;
    }

    public Task<bool> Delete(string path, CancellationToken _)
    {
        if (!Directory.Exists(path))
            return Task.FromResult(false);

        File.Delete(path);

        return Task.FromResult(true);
    }

    public Task<Stream?> Open(string path, CancellationToken _)
    {
        var sourceStream = File.OpenRead(path);

        return Task.FromResult((Stream?)sourceStream);
    }

    public async Task<string> Save(Stream content, CancellationToken cancellationToken)
    {
        var filePath = Path.Combine(_rootFolder, Guid.NewGuid().ToString());

        using FileStream sourceStream = File.Open(filePath, FileMode.Create);
        sourceStream.Seek(0, SeekOrigin.End);

        await content.CopyToAsync(sourceStream, cancellationToken);

        return filePath;
    }
}
