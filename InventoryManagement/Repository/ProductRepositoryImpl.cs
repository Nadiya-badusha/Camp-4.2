using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using InventoryManagement.Model;
using Microsoft.Data.SqlClient;

namespace InventoryManagement.Repository
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private readonly string constring = ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;

        public async Task AddProductAsync(Product product)
        {
            var query = "INSERT INTO Products (ProductCode, ProductName, Category, Quantity, UnitPrice) " +
                        "VALUES (@code, @name, @category, @quantity, @price)";
            try
            {
                await using var connection = new SqlConnection(constring);
                await connection.OpenAsync();

                await using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@code", product.ProductCode);
                command.Parameters.AddWithValue("@name", product.ProductName);
                command.Parameters.AddWithValue("@category", product.Category);
                command.Parameters.AddWithValue("@quantity", product.Quantity);
                command.Parameters.AddWithValue("@price", product.UnitPrice);

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding product: " + ex.Message);
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            var query = "UPDATE Products SET ProductName=@name, Category=@category, Quantity=@quantity, UnitPrice=@price " +
                        "WHERE ProductCode=@code";
            try
            {
                await using var connection = new SqlConnection(constring);
                await connection.OpenAsync();

                await using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@code", product.ProductCode);
                command.Parameters.AddWithValue("@name", product.ProductName);
                command.Parameters.AddWithValue("@category", product.Category);
                command.Parameters.AddWithValue("@quantity", product.Quantity);
                command.Parameters.AddWithValue("@price", product.UnitPrice);

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating product: " + ex.Message);
            }
        }

        public async Task DeleteProductAsync(string productCode)
        {
            var query = "DELETE FROM Products WHERE ProductCode = @code";
            try
            {
                await using var connection = new SqlConnection(constring);
                await connection.OpenAsync();

                await using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@code", productCode);

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting product: " + ex.Message);
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = new List<Product>();
            var query = "SELECT ProductCode, ProductName, Category, Quantity, UnitPrice FROM Products";

            try
            {
                await using var connection = new SqlConnection(constring);
                await connection.OpenAsync();

                await using var command = new SqlCommand(query, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    products.Add(new Product
                    {
                        ProductCode = reader.GetString(0),
                        ProductName = reader.GetString(1),
                        Category = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        UnitPrice = reader.GetDecimal(4)
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving products: " + ex.Message);
            }

            return products;
        }

        public async Task<Product> GetProductByCodeAsync(string productCode)
        {
            Product product = null;
            var query = "SELECT ProductCode, ProductName, Category, Quantity, UnitPrice FROM Products WHERE ProductCode = @code";

            try
            {
                await using var connection = new SqlConnection(constring);
                await connection.OpenAsync();

                await using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@code", productCode);

                await using var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    product = new Product
                    {
                        ProductCode = reader.GetString(0),
                        ProductName = reader.GetString(1),
                        Category = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        UnitPrice = reader.GetDecimal(4)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching product: " + ex.Message);
            }

            return product;
        }
    }
}

