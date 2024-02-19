using AutoMapper;
using Business.Models.Filter;
using Business.Models.Products;
using DataAccess.Utilities;
using Entities.Entities;

namespace Business.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddProductModel, Product>();
            CreateMap<Product, ProductModel>();
            CreateMap<UpdateProductModel, Product>();
        }
    }
}
