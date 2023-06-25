using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleProject.Services;

internal class Program
{
    private static void Main(string[] args)
    {
       

        var _productService = new ProductService();
        var _categories = _productService.GetCategories().GetAwaiter().GetResult();
        


        //Create a menu for the results

        while (true)
        {
            Console.Clear();
            Console.WriteLine("************ Product Catalog ************");
            Console.WriteLine("Available Categories:");

            for (int i = 0; i < _categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_categories[i]}");
            }

            Console.WriteLine($"{_categories.Count + 1}. Exit");
            Console.Write("Enter the category number (1-{_categories.Count}) or press Enter to exit: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            if (int.TryParse(choice, out int categoryNumber))
            {
                if (categoryNumber >= 1 && categoryNumber <= _categories.Count)
                {
                    var selectedCategory = _categories[categoryNumber - 1];
                    ShowProductsByCategory(_productService,selectedCategory);
                }
                else if (categoryNumber == _categories.Count + 1)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid category number. Please try again.");
                }
            }
            else if (string.IsNullOrWhiteSpace(choice))
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        //static void ShowCategories(IProductService? _productService)
        //{
        //    var categoriesTask = _productService.GetCategories();
        //    var categories = categoriesTask.Result;
        //    Console.WriteLine("Categories:");
        //    foreach (var category in categories)
        //    {
        //        Console.WriteLine(category);
        //    }
        //}

        static void ShowProductsByCategory(IProductService? _productService,string category)
        {
            Console.Clear();
            Console.WriteLine($"************ Products in the '{category}' Category ************");

            var products = _productService.GetProductsByCategory(category).GetAwaiter().GetResult();

            if (products != null && products.Count > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"************* {product.Title} *************");
                    Console.WriteLine($"Product ID: {product.Id}");
                    Console.WriteLine($"Title: {product.Title}");
                    Console.WriteLine($"Description: {product.Description}");
                    Console.WriteLine($"Price: ${product.Price:F2}");
                    Console.WriteLine($"Discount Percentage: {product.DiscountPercentage}%");
                    Console.WriteLine($"Rating: {product.Rating}");
                    Console.WriteLine($"Stock: {product.Stock}");
                    Console.WriteLine($"Brand: {product.Brand}");
                    Console.WriteLine("Images:");
                    foreach (var image in product.Images)
                    {
                        Console.WriteLine(image);
                    }
                    Console.WriteLine();
                    Console.WriteLine("***************************************************");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No products found in the specified category.");
            }
        }
    }
}