using AutoMapper;
using Business.Interfaces;
using Business.Models.Filter;
using Business.Models.Pagination;
using Business.Models.Users.Request;
using Business.Models.Users.Response;
using CustomExceptions.UserCustomException;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;
using Entities.Enums;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<UserModel> AddUserAsync(RegisterUserModel model, CancellationToken ct)
        {
            var user = _mapper.Map<User>(model);

            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<UserModel>(user);
        }

        public async Task DeleteUserByIdAsync(Guid id, CancellationToken ct)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(id, ct)
                         ?? throw new UserArgumentException("User by id not exist");

            _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveAsync(ct);
        }

        public async Task<PagedUsersModel> GetAllUserAsync(PaginationModel pagination, CancellationToken ct)
        {
            var mappedPagination = _mapper.Map<PaginationDb>(pagination);

            var result = await _unitOfWork.UserRepository.GetPagedAsync(mappedPagination, ct);
            return _mapper.Map<PagedUsersModel>(result);
        }

        public async Task<PagedUsersModel> GetUsersByFilter(FilterModel model, CancellationToken ct)
        {
            var dbFilter = _mapper.Map<FilterState>(model);
            var result = await _unitOfWork.UserRepository.GetPagedByQueryAsync(dbFilter, ct);
            return _mapper.Map<PagedUsersModel>(result);
        }

        public async Task<UserModel?> GetUserByIdAsync(Guid id, CancellationToken ct)
        {
            var user = await _unitOfWork.UserRepository.GetUserById(id, ct) 
                       ?? throw new UserArgumentException("User by id not exist");
            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> UpdateUserRoleAsync(UpdateUserRoleModel model, CancellationToken ct)
        {
            var userToUpdate = await _unitOfWork.UserRepository.GetUserById(model.Id, ct) 
                               ?? throw new UserArgumentException("User by id not exist");

            userToUpdate.Role = _mapper.Map<Role>(model.Role);

            _unitOfWork.UserRepository.Update(userToUpdate);
            await _unitOfWork.SaveAsync(ct);

            return _mapper.Map<UserModel>(userToUpdate);
        }
    }
}
