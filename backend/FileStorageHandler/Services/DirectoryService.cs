using Entities.Entities;
using Entities.Interfaces;
using FileStorageHandler.Interfaces;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FileStorageHandler.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly ILogger<DirectoryService> _logger;
        /// <summary>
        /// Gets the current directory for files.
        /// </summary>
        private readonly string _projectDirectory;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DirectoryService(ILogger<DirectoryService> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _projectDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Media");
        }

        public async Task CreateFolderAsync(string path, CancellationToken ct)
        {
            var fullPath = Path.Combine(_projectDirectory, path);

            try
            {
                if (!IsDirectoryExist(fullPath))
                {
                    await Task.Run(() => Directory.CreateDirectory(fullPath), cancellationToken: ct);
                    _logger.LogInformation("Folder created successfully: {fullPath}", fullPath);
                }
                else
                    _logger.LogInformation("Folder with this path already exist");
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("Folder creation operation was canceled.");
                await DeleteFolderByPathAsync(path, ct);
            }
            catch (DirectoryNotFoundException e)
            {
                _logger.LogError(e, "Error: Parent directory does not exist.");
            }
            catch (IOException e)
            {
                _logger.LogError(e, "Error creating folder: {fullPath}", fullPath);
            }
            catch (UnauthorizedAccessException e)
            {
                _logger.LogError(e, "Error: Access denied to create folder: {fullPath}", fullPath);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An unexpected error occurred while creating folder: {fullPath}", fullPath);
            }
        }

        public async Task DeleteFolderByPathAsync(string path, CancellationToken ct)
        {
            if (path.StartsWith("/"))
                path = path.Substring(1);

            var fullPath = Path.Combine(_projectDirectory, path);

            try
            {
                if (IsDirectoryExist(fullPath))
                {
                    await Task.Run(() => Directory.Delete(fullPath, true), cancellationToken: ct);
                    _logger.LogInformation($"Folder '{fullPath}' deleted successfully.");
                }
                else
                {
                    _logger.LogWarning($"Folder '{fullPath}' does not exist.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting folder '{fullPath}': {ex.Message}");
                throw;
            }
        }

        public async Task RenameFolderAsync(string oldPath, string newName, CancellationToken ct)
        {
            var fullOldPath = Path.Combine(_projectDirectory, oldPath);

            try
            {
                if (IsDirectoryExist(fullOldPath))
                {
                    var directoryPath = Path.GetDirectoryName(fullOldPath);
                    var newFolderPath = Path.Combine(directoryPath, newName);

                    // Rename the folder asynchronously
                    await Task.Run(() => Directory.Move(fullOldPath, newFolderPath), ct);

                    _logger.LogInformation($"Folder {oldPath} renamed successfully to {newName}");
                }
                else
                {
                    _logger.LogInformation($"The specified folder {oldPath} does not exist.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error with folder");
                throw;
            }
        }

        public bool IsDirectoryExist(string path)
        {
            return Directory.Exists(path);
        }

        public async Task<string> GetDefaultPathAsync<TEntity>(TEntity entity, CancellationToken ct) where TEntity : IEntity
        {

            switch (entity)
            {
                case User user:
                    {
                        var path = Path.Combine("Users", user.Id.ToString());

                        if (!IsDirectoryExist(Path.Combine(_projectDirectory, path)))
                            await CreateFolderAsync(path, ct);

                        return path;
                    }
                case Dish product:
                    {
                        var path = Path.Combine("Dish", product.Title);
                        if (!IsDirectoryExist(Path.Combine(_projectDirectory, path)))
                            await CreateFolderAsync(path, ct);
                        return path;
                    }
                case Category category:
                    {
                        var path = Path.Combine("Category", category.Title);
                        if (!IsDirectoryExist(Path.Combine(_projectDirectory, path)))
                            await CreateFolderAsync(path, ct);
                        return path;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(entity), entity, "Entity not supported");
            }
        }
    }
}
