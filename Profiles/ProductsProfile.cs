using System.Net.Http.Headers;
using AutoMapper;
using Demo.Dtos;
using Demo.Models;

namespace Demo.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductReadDto>();    
            CreateMap<ProductInsertDto, Product>();    
            CreateMap<Product, ProductInsertDto>();    
        }
    }
}