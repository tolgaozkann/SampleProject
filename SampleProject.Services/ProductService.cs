using Newtonsoft.Json;
using SampleProject.Models;

namespace SampleProject.Services
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> GetCategories()
        {
            var url = "https://dummyjson.com/products/categories";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<string>>(content);
            }
            return null;
        }

        public async Task<List<Product>> GetProductsByCategory(string categoryName)
        {
            var url = $"https://dummyjson.com/products/category/{categoryName}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var productData = JsonConvert.DeserializeObject<ProductData>(content);
                return productData.Products;
            }
            return null;
        }
    }
}
