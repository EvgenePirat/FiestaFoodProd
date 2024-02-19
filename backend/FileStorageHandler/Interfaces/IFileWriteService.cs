using Microsoft.AspNetCore.Http;

namespace FileStorageHandler.Interfaces
{
    public interface IFileWriteService
    {
        Task WritePhotoAsync(IFormFile photo, string path, CancellationToken ct);
        Task WriteVideoAsync(IFormFile video, string path, CancellationToken ct);
    }
}
