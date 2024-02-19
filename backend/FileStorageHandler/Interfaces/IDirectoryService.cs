using Entities.Interfaces;

namespace FileStorageHandler.Interfaces
{
    public interface IDirectoryService
    {
        Task<string> GetDefaultPathAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : IEntity;
        Task CreateFolderAsync(string path, CancellationToken ct);
        Task DeleteFolderByPathAsync(string path, CancellationToken ct);
        Task RenameFolderAsync(string oldPath, string newName, CancellationToken ct);
        bool IsDirectoryExist(string path);
    }
}
