using CustomExceptions.FileCustomExceptions;
using FileStorageHandler.Enums;
using FileStorageHandler.Interfaces;
using FileStorageHandler.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FileStorageHandler.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly IFileWriteService _fileWriteService;
        private readonly string _projectDirectory;
        private readonly IDirectoryService _directoryService;
        public FileService(ILogger<FileService> logger, IFileWriteService fileWriteService, IDirectoryService directoryService)
        {
            _logger = logger;
            _fileWriteService = fileWriteService;
            _directoryService = directoryService;
            var currentDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            _projectDirectory = Path.GetFullPath(Path.Combine(currentDirectory, "Media"));
        }
        
        public async Task UploadFilesAsync(IEnumerable<IFormFile> files, string path, CancellationToken ct)
        {
            var fullPath = Path.Combine(_projectDirectory, path);
            if (!_directoryService.IsDirectoryExist(fullPath))
                await _directoryService.CreateFolderAsync(path, ct);
            var filesInDirectory = GetFilesPathsAsync(fullPath);
            foreach (var file in files)
            {
                var fileType = FileTypeChecker.GetFileType(file.ContentType, file.FileName);
                switch (fileType)
                {
                    case SupportedFilesEnum.Image:
                        await _fileWriteService.WritePhotoAsync(file, fullPath, ct);
                        break;
                    case SupportedFilesEnum.Video:
                        await _fileWriteService.WriteVideoAsync(file, fullPath, ct);
                        break;
                    default:
                        throw new FileArgumentException("Not supported file");
                }
            }
        }

        public async Task UploadFileAsync(IFormFile file, string path, CancellationToken ct)
        {
            var fullPath = Path.Combine(_projectDirectory, path);

            if (!_directoryService.IsDirectoryExist(fullPath))
                await _directoryService.CreateFolderAsync(path, ct);

            var filesInDirectory = GetFilesPathsAsync(fullPath);
            var fileType = FileTypeChecker.GetFileType(file.ContentType, file.FileName);
            switch (fileType)
            {
                    case SupportedFilesEnum.Image:
                        await _fileWriteService.WritePhotoAsync(file, fullPath, ct);
                        break;
                    case SupportedFilesEnum.Video:
                        await _fileWriteService.WriteVideoAsync(file, fullPath, ct);
                        break;
                    default:
                        throw new FileArgumentException("Not supported file");
            }
        }

        public async Task DeleteFilesAsync(IEnumerable<string> filesPath, string path)
        {
            try
            {
                _logger.LogInformation("Start to deleting files, {method}");
                foreach (var fileName in filesPath)
                {
                    var filePath = Path.Combine(_projectDirectory, path, fileName);

                    if (File.Exists(filePath))
                    {
                        await Task.Run(()=> File.Delete(filePath));
                        _logger.LogInformation("File '{fileName}' deleted successfully.");
                    }
                    else
                    {
                        _logger.LogInformation("File '{fileName}' not found in the specified folder.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting files");
                throw new FileArgumentException("An error occurred while deleting files");
            }
        }
        
        public IEnumerable<string?> GetFilesPathsAsync(string path)
        {
            if (!Directory.Exists(path)) 
                return Enumerable.Empty<string>();
            var files = Directory.EnumerateFiles(path);
            return files.Select(Path.GetFileName).ToList();
        }
    }
}
