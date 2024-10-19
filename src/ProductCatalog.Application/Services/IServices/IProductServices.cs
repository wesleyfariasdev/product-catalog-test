using ProductCatalog.Application.Dto.Request;
using ProductCatalog.Application.Dto.Response;

namespace ProductCatalog.Application.Services.IServices
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductResponseDto>> GetProductsAsync();
        Task<ProductResponseDto> CreateProduct(ProductRequestDTO product);
    }
}
