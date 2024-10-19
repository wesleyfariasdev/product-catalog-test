using AutoMapper;
using ProductCatalog.Application.Dto.Request;
using ProductCatalog.Application.Dto.Response;
using ProductCatalog.Domain.Models;

namespace ProductCatalog.Application.Mappings
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            CreateMap<Product, ProductRequestDTO>().ReverseMap();
            CreateMap<Product, ProductResponseDto>().ReverseMap();
        }
    }
}
