using ProductCatalog.Application.Dto.Request;
using ProductCatalog.Domain.AuxModels;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Application.Test.Dto
{
    public class ProductRequestDTOTests
    {
        [Fact]
        public void ProductRequestDTO_ValidatesCorrectly_WhenAllPropertiesAreValid()
        {
            var productRequest = new ProductRequestDTO
            {
                Name = "Produto Teste",
                Price = 10.99m,
                Description = "Descrição do produto",
                ProductType = ProductType.ORGANICO,
                RegistrationDate = DateTime.UtcNow
            };

            var validationResults = ValidateModel(productRequest);

            Assert.Empty(validationResults);
        }

        [Fact]
        public void ProductRequestDTO_ThrowsValidationError_WhenNameIsEmpty()
        {
            var productRequest = new ProductRequestDTO
            {
                Name = string.Empty,
                Price = 10.99m,
                Description = "Descrição do produto",
                ProductType = ProductType.ORGANICO,
                RegistrationDate = DateTime.UtcNow
            };

            var validationResults = ValidateModel(productRequest);

            Assert.Single(validationResults);
            Assert.Equal("O nome do produto é obrigatório.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void ProductRequestDTO_ThrowsValidationError_WhenPriceIsZero()
        {
            var productRequest = new ProductRequestDTO
            {
                Name = "Produto Teste",
                Price = 0m,
                Description = "Descrição do produto",
                ProductType = ProductType.NAO_ORGANICO,
                RegistrationDate = DateTime.UtcNow
            };

            var validationResults = ValidateModel(productRequest);

            Assert.Single(validationResults);
            Assert.Equal("O preço deve ser maior que zero.", validationResults[0].ErrorMessage);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }
    }
}
