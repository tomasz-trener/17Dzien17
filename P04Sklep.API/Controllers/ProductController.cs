using Microsoft.AspNetCore.Mvc;
using P04Sklep.API.Services.ProductService;
using P05Sklep.Shared;

namespace P04Sklep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceReponse<Product[]>>> GetProducts()
        {
            var result = await _productService.GetProductAsync();
            return Ok(result);
            //  ProductService productService = new ProductService();
        }

        [HttpPut]
        public async Task<ActionResult<ServiceReponse<Product>>> UpdateProduct(Product product)
        {
            var results = await _productService.UpdateProduct(product);
            return Ok(results);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceReponse<Product[]>>> CreateProduct([FromBody] Product product)
        {
            var result = await _productService.CreateProduct(product);
            return Ok(result);
        }


        // https://localhost:7140/api/product/4
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceReponse<bool>>> DeleteProduct([FromRoute] int id)
        {
            var result = await _productService.DeleteProductAsync(id);
            return Ok(result);
        }
    }
}
