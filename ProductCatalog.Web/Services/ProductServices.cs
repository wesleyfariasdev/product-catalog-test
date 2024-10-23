using ProductCatalog.Application.Dto.Request;
using ProductCatalog.Application.Dto.Response;
using ProductCatalog.Web.Response;
using System.Text;
using System.Text.Json;

namespace ProductCatalog.Web.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductResponse> GetProductsAsync(int page = 1, int pageSize = 5)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7113/api/product?page={page}&pageSize={pageSize}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            throw new Exception("Erro ao carregar produtos");
        }

        public async Task<ProductResponseDto> CreateNewProductAsync(ProductRequestDTO product)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("https://localhost:7113/api/Product", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductResponseDto>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                throw new Exception($"Failed to create product: {response.ReasonPhrase}");
            }
        }

    }

}
