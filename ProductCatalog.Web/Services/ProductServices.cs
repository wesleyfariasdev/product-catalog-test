using ProductCatalog.Web.Response;
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
    }

}
