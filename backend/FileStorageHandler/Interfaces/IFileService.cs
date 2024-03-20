using Microsoft.AspNetCore.Http;

namespace FileStorageHandler.Interfaces
{
    public interface IFileService
    {
        Task UploadFilesAsync(IEnumerable<IFormFile> files, string path, CancellationToken ct);
        Task UploadFileAsync(IFormFile file, string path, CancellationToken ct);
        Task DeleteFilesAsync(IEnumerable<string> filesPath, string path);
        IEnumerable<string?> GetFilesPathsAsync(string path);
    }
}
