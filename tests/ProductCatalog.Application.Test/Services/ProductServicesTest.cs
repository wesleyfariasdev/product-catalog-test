using AutoMapper;
using Moq;
using ProductCatalog.Application.Dto.Response;
using ProductCatalog.Application.Services;
using ProductCatalog.Domain.AuxModels;
using ProductCatalog.Domain.Interface;
using ProductCatalog.Domain.Models;

namespace ProductCatalog.Application.Test.Services
{
    public class ProductServicesTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductServices _productServices;

        public ProductServicesTest()
        {
            _mapperMock = new Mock<IMapper>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _productServices = new ProductServices(_mapperMock.Object, _productRepositoryMock.Object);
        }

        [Fact]
        public async Task GetProductsAsync_ReturnsProducts_WhenSuccessful()
        {
            var productList = new List<Product>();
            Product product1 = new Product("Produto 1", 10.99m, "Descrição 1", ProductType.ORGANICO);

            Product product2 = new Product("Produto 2", 20.99m, "Descrição 2", ProductType.ORGANICO);
            productList.Add(product1);
            productList.Add(product2);


            var productResponseList = new List<ProductResponseDto>
        {
            new ProductResponseDto { Id = 1, Name = "Produto 1", Price = 10.99m, Description = "Descrição 1", ProductType = ProductType.ORGANICO, RegistrationDate = DateTime.UtcNow },
            new ProductResponseDto { Id = 2, Name = "Produto 2", Price = 20.99m, Description = "Descrição 2", ProductType = ProductType.ORGANICO, RegistrationDate = DateTime.UtcNow }
        };

            _productRepositoryMock.Setup(repo => repo.GetProductsAsync()).ReturnsAsync(productList);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<ProductResponseDto>>(It.IsAny<IEnumerable<Product>>())).Returns(productResponseList);

            var result = await _productServices.GetProductsAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _productRepositoryMock.Verify(repo => repo.GetProductsAsync(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<IEnumerable<ProductResponseDto>>(productList), Times.Once);
        }

        [Fact]
        public async Task GetProductsAsync_ThrowsException_WhenRepositoryFails()
        {
            _productRepositoryMock.Setup(repo => repo.GetProductsAsync()).ThrowsAsync(new Exception("Erro ao obter produtos"));

            var exception = await Assert.ThrowsAsync<Exception>(() => _productServices.GetProductsAsync());
            Assert.Equal("Erro ao obter produtos", exception.Message);
        }
    }
}
