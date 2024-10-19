using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Dto.Request;
using ProductCatalog.Application.Dto.Response;
using ProductCatalog.Application.Services.IServices;

namespace ProductCatalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductServices productService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDTO productRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productResponse = await productService.CreateProductAsync(productRequest);
            return CreatedAtAction(nameof(GetAllProducts), new { id = productResponse.Id + 1 }, productResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(int page = 1, int pageSize = 5)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 5;

            var products = await productService.GetProductsAsync() ?? new List<ProductResponseDto>();

            // Paginação
            var paginatedProducts = products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new
            {
                TotalCount = products.Count(),
                Page = page,
                PageSize = pageSize,
                Products = paginatedProducts
            });
        }

    }
}