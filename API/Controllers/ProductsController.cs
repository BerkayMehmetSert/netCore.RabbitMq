using API.Application.Requests;
using API.Application.Responses;
using API.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductRequest request)
        {
            var response = await _productService.CreateProduct(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponse>> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
        {
            var response = await _productService.UpdateProduct(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] Guid id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProductById([FromRoute] Guid id)
        {
            var response = await _productService.GetProductById(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponse>>> GetProducts()
        {
            var response = await _productService.GetProducts();
            return Ok(response);
        }
    }
}
