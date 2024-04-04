using AutoMapper;
using Business.Models.Categories.Request;
using Business.Models.Categories.Response;
using Entities.Entities;

namespace Business.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryModel, Category>();
            CreateMap<UpdateCategoryModel, Category>();
            CreateMap<Category, CategoryModel>();
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
