using AutoMapper;
using Business.Models.Users.Request;
using Business.Models.Users.Response;
using Entities.Entities;
using Entities.Pagination;

namespace Business.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UpdateUserModel, User>();
            CreateMap<RegisterUserModel, User>();

            CreateMap<User, UserModel>();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
