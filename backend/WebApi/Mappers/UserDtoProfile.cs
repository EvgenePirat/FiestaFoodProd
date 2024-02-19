using AutoMapper;
using Business.Models.Users.Request;
using Business.Models.Users.Response;
using WebApi.Models.User.Request;
using WebApi.Models.User.Response;

namespace WebApi.Mappers
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<AddUserDto, RegisterUserModel>();

            CreateMap<UpdateUserRoleDto, UpdateUserModel>();

            CreateMap<UserModel, UserDto>();

            CreateMap<UserModel, UserDto>().ReverseMap();

            CreateMap<PagedUsersModel, PagedUsersDto>();
        }
    }
}
