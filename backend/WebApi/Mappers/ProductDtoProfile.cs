using AutoMapper;
using Business.Models.Pagination;
using Business.Models.Products;
using WebApi.Models.PaginationsDto;
using WebApi.Models.ProductsDto.Request;
using WebApi.Models.ProductsDto.Response;

namespace WebApi.Mappers
{
    public class ProductDtoProfile : Profile
    {
        public ProductDtoProfile()
        {
            CreateMap<AddProductDto, AddProductModel>();
            CreateMap<ProductModel, ProductDto>();
            CreateMap<PaginationDto, PaginationModel>();
            CreateMap<UpdateProductDto, UpdateProductModel>();
            CreateMap<PagedProductModel, PagedProductDto>();
        }
    }
}
