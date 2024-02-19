using CustomExceptions.FileCustomExceptions;
using FileStorageHandler.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.PixelFormats;
using System.Security.Cryptography;

namespace FileStorageHandler.Services
{
    public class FileWriterService : IFileWriteService
    {
        private readonly ILogger<FileWriterService> _logger;

        public FileWriterService(ILogger<FileWriterService> logger)
        {
            _logger = logger;
        }

        public async Task WritePhotoAsync(IFormFile photo, string path, CancellationToken ct)
        {
            _logger.LogInformation($"Photo {photo.FileName} is starting to load");
            var lastFolder = Path.GetFileName(path);
            var fileName = $"{lastFolder}-{GetHashFileName(photo)}";
            using (var imageStream = new MemoryStream())
            {
                await photo.CopyToAsync(imageStream, cancellationToken: ct);
                imageStream.Seek(0, SeekOrigin.Begin);

                // Load the image from the stream
                using (var image = Image.Load<Rgb24>(imageStream))
                {
                    if (image.Width == 0 || image.Height == 0)
                    {
                        _logger.LogError($"Image {photo.FileName} unable to convert, dimensions of image - 0");
                        throw new FileArgumentException("Failed to load image.");
                    }
                    var encoder = new WebpEncoder
                    {
                        Quality = 100,
                        Method = WebpEncodingMethod.BestQuality
                    };

                    // Encode the image to WebP
                    await using (var webPStream = new MemoryStream())
                    {
                        // Todo: implement cancellationToken
                        await encoder.EncodeAsync(image, webPStream, cancellationToken: ct);

                        await image.SaveAsync(webPStream, encoder, cancellationToken: ct);
                        // Save the WebP file
                        await using (var fileStream = new FileStream(Path.Combine(path, fileName + ".webp"), FileMode.Create))
                        {
                            await image.SaveAsWebpAsync(fileStream, cancellationToken: ct);
                            _logger.LogInformation($"Image {photo.FileName} converted and uploaded successful");
                        }
                    }
                }
            }
        }

        public async Task WriteVideoAsync(IFormFile video, string path, CancellationToken ct)
        {
            _logger.LogInformation($"Video {video.FileName} is starting to load");
            var fileName = GetHashFileName(video);
            var fullPath = Path.Combine(path, fileName);

            // Write the video file to disk
            using (var fileStream = new FileStream(fullPath + ".webm", FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
            {
                await video.CopyToAsync(fileStream, cancellationToken: ct);
                _logger.LogInformation($"Video {video.FileName} uploaded successful");
            }
        }

        private string GetHashFileName(IFormFile file)
        {
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(file.OpenReadStream());
                return Convert.ToBase64String(hash).Replace("/", "_");
            }
        }
    }
}
