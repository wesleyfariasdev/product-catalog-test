using ProductCatalog.Domain.Models;

namespace ProductCatalog.Domain.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> CreateProduct(Product product);
    }
}
