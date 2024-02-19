using FileStorageHandler.Validations;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FileStorageHandler.Enums;

namespace WebApi.Utilities.Filters.FormFileFilter
{
    public class FormFileOperationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ActionArguments.TryGetValue("file", out var argument))
            {
                if (argument is IFormFile file)
                {
                    // Validate the file type for image and video
                    var fileType = FileTypeChecker.GetFileType(file.ContentType, file.FileName);
                    if (Enum.IsDefined(typeof(SupportedFilesEnum), fileType))
                    {
                        context.Result = 
                            new BadRequestObjectResult("Invalid file type. Only image and video files are allowed.");
                        return;
                    }
                    context.HttpContext.Items["file"] = file;
                }
            }
            await next();
        }
    }
}

