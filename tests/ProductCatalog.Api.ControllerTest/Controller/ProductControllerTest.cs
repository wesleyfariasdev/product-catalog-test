using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductCatalog.Api.Controllers;
using ProductCatalog.Application.Dto.Request;
using ProductCatalog.Application.Dto.Response;
using ProductCatalog.Application.Services.IServices;
using ProductCatalog.Domain.AuxModels;

namespace ProductCatalog.Api.ControllerTest.Controller
{
    public class ProductControllerTest
    {
        [Fact]
        public async Task CreateProduct_ValidModel_ReturnsCreatedAtAction()
        {
            var productRequest = new ProductRequestDTO { Name = "Product A", Price = 10.00m, ProductType = ProductType.ORGANICO, RegistrationDate = DateTime.UtcNow };
            var productResponse = new ProductResponseDto { Id = 1, Name = "Product A", Price = 10.00m, ProductType = ProductType.ORGANICO, RegistrationDate = DateTime.UtcNow };

            var productServiceMock = new Mock<IProductServices>();
            productServiceMock.Setup(s => s.CreateProductAsync(productRequest)).ReturnsAsync(productResponse);

            var controller = new ProductController(productServiceMock.Object);

            var result = await controller.CreateProduct(productRequest);

            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnedProduct = Assert.IsType<ProductResponseDto>(actionResult.Value);
            Assert.Equal(productResponse.Id, returnedProduct.Id);
        }

    }
}
