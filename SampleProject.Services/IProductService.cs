using SampleProject.Models;

namespace SampleProject.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsByCategory(string categoryName);
        public Task<List<string>> GetCategories();

    }
}
