using Microsoft.AspNetCore.Http;

namespace FileStorageHandler.Utils
{
    public class ApiDomain
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _domain;

        public ApiDomain(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            if (string.IsNullOrEmpty(_domain))
            {
                var request = _httpContextAccessor.HttpContext?.Request;
                _domain = $"{request?.Scheme}://{request?.Host}";
            }
        }

        public string GetCurrentDomain()
        {
            return _domain;
        }
    }
}
