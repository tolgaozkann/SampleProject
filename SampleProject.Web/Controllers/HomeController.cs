using Microsoft.AspNetCore.Mvc;
using SampleProject.Services;
using SampleProject.Web.Models;
using System.Diagnostics;

namespace SampleProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger,IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var categories = _productService.GetCategories().GetAwaiter().GetResult();
            var listOfCategories = new List<CategoryViewModel>();
            
            foreach (var category in categories)
            {
                var categoryView = new CategoryViewModel
                {
                    Name = category
                };

                listOfCategories.Add(categoryView);
            }
            var categoryProductModel = new CategoryProductViewModel();
            categoryProductModel.Categories = listOfCategories;
            var dummyProducts = _productService.GetProductsByCategory(categories[0]).GetAwaiter().GetResult();
            var products = new List<ProductViewModel>();
            foreach (var product in dummyProducts)
            {
                var productModel = new ProductViewModel
                {
                    Category = product.Category,
                    Brand = product.Brand,
                    Description = product.Description,
                    DiscountPercentage = product.DiscountPercentage,
                    Id = product.Id,
                    Images = product.Images,
                    Price = product.Price,
                    Rating = product.Rating,
                    Stock = product.Stock,
                    Thumbnail = product.Thumbnail,
                    Title = product.Title
                };
                products.Add(productModel);
            }
            categoryProductModel.Products = products;
            return View(categoryProductModel);
        }

        [HttpPost]
        public IActionResult Index(string category)
        {
            var products = _productService.GetProductsByCategory(category).GetAwaiter().GetResult();
            var listOfProducts = new List<ProductViewModel>();
            var categories = _productService.GetCategories().GetAwaiter().GetResult();
            var listOfCategories = new List<CategoryViewModel>();

            foreach (var ct in categories)
            {
                var categoryView = new CategoryViewModel
                {
                    Name = ct
                };

                listOfCategories.Add(categoryView);
            }

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Category = product.Category,
                    Brand = product.Brand,
                    Description = product.Description,
                    DiscountPercentage = product.DiscountPercentage,
                    Id = product.Id,
                    Images = product.Images,
                    Price = product.Price,
                    Rating = product.Rating,
                    Stock = product.Stock,
                    Thumbnail = product.Thumbnail,
                    Title = product.Title,
                };
                listOfProducts.Add(productViewModel);
            }

            var categoryProductModel = new CategoryProductViewModel();
            categoryProductModel.Products = listOfProducts;
            categoryProductModel.Categories = listOfCategories;
            return View(categoryProductModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}