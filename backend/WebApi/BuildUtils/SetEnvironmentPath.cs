using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace WebApi.BuildUtils
{
    public class SetEnvironmentPath
    {
        private readonly WebApplicationBuilder _builder;
        public SetEnvironmentPath(WebApplicationBuilder builder)
        {
            _builder = builder;
        }

        public void SetDefaultStoragePathForProject()
        {
            var directory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            var currentDirectory = Path.GetFullPath(Path.Combine(directory!));
            var fullPath = Path.GetFullPath(currentDirectory);
            _builder.Environment.WebRootPath = fullPath;
        }
    }
}
