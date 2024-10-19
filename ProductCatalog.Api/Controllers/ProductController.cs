using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Application.Dto.Request;
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
            return CreatedAtAction(nameof(GetAllProducts), new { id = productResponse.Id }, productResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productService.GetProductsAsync();
            return Ok(products);
        }
    }
}