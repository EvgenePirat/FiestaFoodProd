using FileStorageHandler.Interfaces;
using FileStorageHandler.Utils;
using Microsoft.AspNetCore.Http;

namespace FileStorageHandler.Services
{
    public class MediaHandlerService : IMediaHandlerService
    {
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _currentApiDomain;
        public MediaHandlerService(IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
            var apiDomain = new ApiDomain(_httpContextAccessor);
            _currentApiDomain = apiDomain.GetCurrentDomain();
        }

        public async Task<IEnumerable<string>> GetAllPhotosByPathAsync(string path, CancellationToken ct)
        {
            var mediasPath = _fileService.GetFilesPathsAsync(path);
            if (mediasPath is null || !mediasPath.Any())
                return Enumerable.Empty<string>();

            return mediasPath.Select(mediaPath => _currentApiDomain + $"/{path}/" + mediaPath).Select(url => url.Replace("\\", "/")).ToList();
        }

        public async Task<string> GetPhotoByPathAsync(string path, CancellationToken ct)
        {
            var mediaPath = _fileService.GetFilesPathsAsync(path).FirstOrDefault();
            if(string.IsNullOrEmpty(mediaPath))
                return string.Empty;
            var urlPath = _currentApiDomain + "/Media" + $"/{path}/" + mediaPath;
            return urlPath.Replace("\\", "/");
        }
    }
}
