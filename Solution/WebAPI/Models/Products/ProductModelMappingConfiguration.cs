using AutoMapper;
using Domain.Entities;

namespace WebAPI.Models.Products
{
    public class ProductModelMappingConfiguration : Profile
    {
        public ProductModelMappingConfiguration()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
