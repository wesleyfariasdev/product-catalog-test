using ProductCatalog.Domain.Interface;
using ProductCatalog.Domain.Models;

namespace ProductCatalog.Infra.Data.Repository
{
    public class ProductRepository(List<Product> initialProducts) : IProductRepository
    {
        private readonly List<Product> _products = initialProducts;
        public Task<Product> CreateProduct(Product product)
        {
            _products.Add(product);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return Task.FromResult(_products.AsEnumerable());
        }
    }
}
