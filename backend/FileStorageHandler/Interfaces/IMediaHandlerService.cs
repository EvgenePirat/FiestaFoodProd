namespace FileStorageHandler.Interfaces
{
    public interface IMediaHandlerService
    {
        Task<IEnumerable<string>> GetAllPhotosByPathAsync(string path, CancellationToken ct);
        Task<string> GetPhotoByPathAsync(string path, CancellationToken ct);
    }
}
