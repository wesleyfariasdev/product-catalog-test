using ProductCatalog.Domain.AuxModels;
using System.Text.Json.Serialization;

namespace ProductCatalog.Application.Dto.Response
{
    public sealed class ProductResponseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; init; }

        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [JsonPropertyName("product_type")]
        public ProductType ProductType { get; init; }

        [JsonPropertyName("registration_date")]
        public DateTime RegistrationDate { get; init; }
    }
}
