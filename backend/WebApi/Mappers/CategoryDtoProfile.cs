using AutoMapper;
using Business.Models.Categories;
using WebApi.Models.CategoriesDto.Request;
using WebApi.Models.CategoriesDto.Response;

namespace WebApi.Mappers
{
    public class CategoryDtoProfile : Profile   
    {
        public CategoryDtoProfile()
        {
            CreateMap<CreateCategoryDto, CreateCategoryModel>();

            CreateMap<CategoryDto, CategoryModel>();
            CreateMap<CategoryDto, CategoryModel>().ReverseMap();

            CreateMap<UpdateCategoryDto, UpdateCategoryModel>();
        }
    }
}
