using WMSSystems.Models;
using WMSSystems.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WMSSystems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("products")]
        public async Task<List<Product>> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return products is List<Product> list ? list : new List<Product>(products);
        }

        [HttpGet]
        [Route("products/{id}")]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
                return NotFound();
            return product;
        }

        [HttpPost]
        [Route("products")]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.productCode }, product);
        }

        [HttpPut]
        [Route("products/{id}")]
        public async Task<ActionResult> UpdateProduct(string id, [FromBody] Product product)
        {
            if (id != product.productCode)
                return BadRequest();

            await _productService.UpdateProductAsync(product);
            return NoContent();
        }

        [HttpDelete]
        [Route("products/{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}