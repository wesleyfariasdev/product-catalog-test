using ProductCatalog.Application.Dto.Response;
using ProductCatalog.Domain.AuxModels;
using System.Text.Json;

namespace ProductCatalog.Application.Test.Dto
{
    public class ProductResponseDtoTests
    {
        [Fact]
        public void ProductResponseDto_CanBeSerializedAndDeserialized()
        {
            var productResponse = new ProductResponseDto
            {
                Id = 1,
                Name = "Produto Teste",
                Price = 10.99m,
                Description = "Descrição do produto",
                ProductType = ProductType.ORGANICO,
                RegistrationDate = DateTime.UtcNow
            };

            var json = JsonSerializer.Serialize(productResponse);
            var deserializedProductResponse = JsonSerializer.Deserialize<ProductResponseDto>(json);

            Assert.NotNull(deserializedProductResponse);
            Assert.Equal(productResponse.Id, deserializedProductResponse.Id);
            Assert.Equal(productResponse.Name, deserializedProductResponse.Name);
            Assert.Equal(productResponse.Price, deserializedProductResponse.Price);
            Assert.Equal(productResponse.Description, deserializedProductResponse.Description);
            Assert.Equal(productResponse.ProductType, deserializedProductResponse.ProductType);
            Assert.Equal(productResponse.RegistrationDate, deserializedProductResponse.RegistrationDate);
        }
    }
}
