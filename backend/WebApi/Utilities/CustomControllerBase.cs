using Microsoft.AspNetCore.Mvc;

namespace WebApi.Utilities
{
    /// <summary>
    /// Generic class for hold 3 main details for working with controllers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
    }
}