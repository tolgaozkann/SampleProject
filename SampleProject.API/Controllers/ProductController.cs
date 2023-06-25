using Microsoft.AspNetCore.Mvc;
using SampleProject.API.Models;
using SampleProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<string>>> GetCategories()
        {
            var categories = await _productService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategory(string category)
        {
            var products = await _productService.GetProductsByCategory(category);
            if (products != null && products.Count > 0)
            {
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }






    }
}
