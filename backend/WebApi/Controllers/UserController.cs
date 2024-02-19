using AutoMapper;
using Business.Interfaces;
using Business.Models.Filter;
using Business.Models.Pagination;
using Business.Models.Users.Request;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.FiltersDto;
using WebApi.Models.PaginationsDto;
using WebApi.Models.User.Request;
using WebApi.Models.User.Response;
using WebApi.Utilities;

namespace WebApi.Controllers
{
    public class UserController : CustomControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryController> _logger;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, ILogger<CategoryController> logger, IUserService userService)
        {
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("by-id")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync(Guid id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, Get User by id, Task started", 
                nameof(UserController), nameof(GetAllUserAsync));

            var result = await _userService.GetUserByIdAsync(id, ct);

            var mappedResult = _mapper.Map<UserDto>(result);

            _logger.LogInformation("{controller}.{method} - Get, Get User by id,Result Ok, Task finished", 
                nameof(UserController), nameof(GetAllUserAsync));

            return Ok(mappedResult);
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserDto>> CreateUserAsync(AddUserDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Post, Create User, Task started", 
                nameof(UserController), nameof(GetAllUserAsync));

            var mappedUser = _mapper.Map<RegisterUserModel>(model);

            var result = await _userService.AddUserAsync(mappedUser, ct);

            var mappedResult = _mapper.Map<UserDto>(result);

            _logger.LogInformation("{controller}.{method} - Post, Create User, Result Ok, Task finished", 
                nameof(UserController), nameof(GetAllUserAsync));

            return Ok(mappedResult);
        }

        [HttpGet("all")]
        public async Task<ActionResult<PagedUsersDto>> GetAllUserAsync([FromQuery]PaginationDto pagination, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, get all users, Task started", 
                nameof(UserController), nameof(GetAllUserAsync));

            var mappedPagination = _mapper.Map<PaginationModel>(pagination);

            var users = await _userService.GetAllUserAsync(mappedPagination, ct);

            var mappedUsers = _mapper.Map<PagedUsersDto>(users);

            _logger.LogInformation("{controller}.{method} - Get, get all users, Result Ok, Task finished", 
                nameof(UserController), nameof(GetAllUserAsync));

            return Ok(mappedUsers);
        }

        [HttpGet("by-query")]
        public async Task<ActionResult<PagedUsersDto>> GetUsersByQueryAsync([FromQuery] FilterDto filter, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Get, get all users by query, Task started",
                nameof(UserController), nameof(GetUsersByQueryAsync));

            var mappedFilter = _mapper.Map<FilterModel>(filter);

            var result = await _userService.GetUsersByFilter(mappedFilter, ct);

            var mappedResult = _mapper.Map<PagedUsersDto>(result);

            _logger.LogInformation("{controller}.{method} - Get, get all users by query, Result Ok, Task finished",
                nameof(UserController), nameof(GetUsersByQueryAsync));

            return Ok(mappedResult);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUserAsync(Guid id, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Delete, delete user, Task started", 
                nameof(UserController), nameof(DeleteUserAsync));

            await _userService.DeleteUserByIdAsync(id, ct);

            _logger.LogInformation("{controller}.{method} - Delete, delete user, Result Ok, Task finished", 
                nameof(UserController), nameof(DeleteUserAsync));

            return Ok("User was deleted");
        }

        [HttpPut("update")]
        public async Task<ActionResult<UserDto>> UpdateUserAsync([FromForm] UpdateUserRoleDto model, CancellationToken ct)
        {
            _logger.LogInformation("{controller}.{method} - Put, Update User Role, Task started", 
                nameof(UserController), nameof(GetAllUserAsync));

            var mappedModel = _mapper.Map<UpdateUserRoleModel>(model);

            var result = await _userService.UpdateUserRoleAsync(mappedModel, ct);

            var mappedResult = _mapper.Map<UserDto>(result);

            _logger.LogInformation("{controller}.{method} - Put, Update User Role, Result Ok, Task finished", 
                nameof(UserController), nameof(GetAllUserAsync));

            return Ok(mappedResult);
        }
    }
}
