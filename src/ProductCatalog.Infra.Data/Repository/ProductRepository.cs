using ProductCatalog.Domain.Interface;
using ProductCatalog.Domain.Models;

namespace ProductCatalog.Infra.Data.Repository
{
    public class ProductRepository(List<Product> initialProducts) : IProductRepository
    {
        private readonly List<Product> _products = initialProducts;
        private static int _nextId = 1;

        public Task<Product> CreateProduct(Product product)
        {
            product = new Product(_nextId++, product.Name, product.Price, product.Description, product.ProductType, DateTime.UtcNow);
            _products.Add(product);
            return Task.FromResult(product);
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return Task.FromResult(_products.AsEnumerable());
        }
    }
}
