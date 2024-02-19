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

            CreateMap<PaginationResult<CustomerInfo>, PagedUsersModel>()
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Result));
        }
    }
}
