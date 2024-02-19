using Business.Models.Filter;
using Business.Models.Pagination;
using Business.Models.Users.Request;
using Business.Models.Users.Response;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> GetUserByIdAsync(Guid id, CancellationToken ct);

        Task<UserModel> AddUserAsync(RegisterUserModel model, CancellationToken ct);

        Task<UserModel> UpdateUserRoleAsync(UpdateUserRoleModel model, CancellationToken ct);

        Task DeleteUserByIdAsync(Guid id, CancellationToken ct);

        Task<PagedUsersModel> GetAllUserAsync(PaginationModel model,CancellationToken ct);

        Task<PagedUsersModel> GetUsersByFilter(FilterModel model, CancellationToken ct);
    }
}
