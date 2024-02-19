using CustomExceptions.FileCustomExceptions;
using FileStorageHandler.Enums;

namespace FileStorageHandler.Validations
{

    public static class FileTypeChecker
    {
        public static SupportedFilesEnum GetFileType(string contentType, string fileName)
        {
            // If ContentType available
            if (!string.IsNullOrEmpty(contentType))
            {
                if (contentType.StartsWith("image/"))
                {
                    return SupportedFilesEnum.Image;
                }

                if (contentType.StartsWith("video/"))
                {
                    return SupportedFilesEnum.Video;
                }
            }

            // If Content-Type is unavailable
            var extension = Path.GetExtension(fileName);

            if (ImageExtensions.Contains(extension))
            {
                return SupportedFilesEnum.Image;
            }

            if (VideoExtensions.Contains(extension))
            {
                return SupportedFilesEnum.Video;
            }

            // Handle unknown or unsupported file types
            throw new FileArgumentException("Unsupported file format, only image or video");
        }

        private static readonly HashSet<string> ImageExtensions = new(StringComparer.OrdinalIgnoreCase)
        {
            ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp",
        };

        private static readonly HashSet<string> VideoExtensions = new(StringComparer.OrdinalIgnoreCase)
        {
            ".mp4", ".mov", ".avi", ".webm", ".wmv", ".flv",
        };
    }
}
