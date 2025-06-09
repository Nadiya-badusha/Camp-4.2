using System;
using System.Threading.Tasks;
using InventoryManagement.Model;
using InventoryManagement.Repository;
using InventoryManagement.Service;

namespace InventoryManagement
{
    internal class Program
    {
        private static IProductService _productService;

        static async Task Main(string[] args)
        {
            _productService = new ProductServiceImpl(new ProductRepositoryImpl());

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. List All Products");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddProductAsync();
                        break;
                    case "2":
                        await UpdateProductAsync();
                        break;
                    case "3":
                        await DeleteProductAsync();
                        break;
                    case "4":
                        await ListProductsAsync();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static async Task AddProductAsync()
        {
            Console.WriteLine("Enter product details:");

            Console.Write("Product Code: ");
            var code = Console.ReadLine();

            Console.Write("Product Name: ");
            var name = Console.ReadLine();

            Console.Write("Category: ");
            var category = Console.ReadLine();

            Console.Write("Quantity: ");
            int.TryParse(Console.ReadLine(), out int quantity);

            Console.Write("Unit Price: ");
            decimal.TryParse(Console.ReadLine(), out decimal price);

            var product = new Product(code, name, category, quantity, price);
            await _productService.AddProductAsync(product);

            Console.WriteLine("Product added successfully! Press any key to continue...");
            Console.ReadKey();
        }

        private static async Task UpdateProductAsync()
        {
            Console.Write("Enter Product Code to update: ");
            var code = Console.ReadLine();

            var existingProduct = await _productService.GetProductByCodeAsync(code);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found! Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter new details (leave blank to keep existing):");

            Console.Write($"Product Name ({existingProduct.ProductName}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                existingProduct.ProductName = name;

            Console.Write($"Category ({existingProduct.Category}): ");
            var category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category))
                existingProduct.Category = category;

            Console.Write($"Quantity ({existingProduct.Quantity}): ");
            var quantityInput = Console.ReadLine();
            if (int.TryParse(quantityInput, out int quantity))
                existingProduct.Quantity = quantity;

            Console.Write($"Unit Price ({existingProduct.UnitPrice}): ");
            var priceInput = Console.ReadLine();
            if (decimal.TryParse(priceInput, out decimal price))
                existingProduct.UnitPrice = price;

            await _productService.UpdateProductAsync(existingProduct);

            Console.WriteLine("Product updated successfully! Press any key to continue...");
            Console.ReadKey();
        }

        private static async Task DeleteProductAsync()
        {
            Console.Write("Enter Product Code to delete: ");
            var code = Console.ReadLine();

            var existingProduct = await _productService.GetProductByCodeAsync(code);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found! Press any key to continue...");
                Console.ReadKey();
                return;
            }

            await _productService.DeleteProductAsync(code);
            Console.WriteLine("Product deleted successfully! Press any key to continue...");
            Console.ReadKey();
        }

        private static async Task ListProductsAsync()
        {
            var products = await _productService.GetAllProductsAsync();

            Console.WriteLine("\nProductCode  | ProductName           | Category          | Quantity | UnitPrice");
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (var p in products)
            {
                Console.WriteLine($"{p.ProductCode,-12} | {p.ProductName,-20} | {p.Category,-16} | {p.Quantity,8} | {p.UnitPrice,9:C}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}


