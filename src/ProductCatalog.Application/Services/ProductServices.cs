using AutoMapper;
using ProductCatalog.Application.Dto.Request;
using ProductCatalog.Application.Dto.Response;
using ProductCatalog.Application.Services.IServices;
using ProductCatalog.Domain.Interface;
using ProductCatalog.Domain.Models;

namespace ProductCatalog.Application.Services
{
    public class ProductServices(IMapper mapper, IProductRepository productRepository) : IProductServices
    {
        public async Task<ProductResponseDto> CreateProductAsync(ProductRequestDTO productRequest)
        {
            var product = mapper.Map<Product>(productRequest);
            return mapper.Map<ProductResponseDto>(await productRepository.CreateProduct(product));
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductsAsync()
        {
            var products = await productRepository.GetProductsAsync();
            return mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }
    }
}
