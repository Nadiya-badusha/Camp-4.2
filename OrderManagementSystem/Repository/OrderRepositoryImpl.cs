using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OrderManagementSystem.Model;

namespace OrderManagementSystem.Repository
{
    public class OrderRepositoryImpl : IOrderRepository
    {
        private readonly string constring =ConfigurationManager.ConnectionStrings["CsWin"].ConnectionString;

        public async Task AddOrderAsync(Order order)
        {
            try
            {
                using SqlConnection connection = new(constring);
                await connection.OpenAsync();

                string query = "INSERT INTO Orders (CustomerName, ProductCode, Quantity, TotalPrice) " +
                               "VALUES (@CustomerName, @ProductCode, @Quantity, @TotalPrice)";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                command.Parameters.AddWithValue("@ProductCode", order.ProductCode);
                command.Parameters.AddWithValue("@Quantity", order.Quantity);
                command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);

                int rows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"{rows} order(s) added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding order to database");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateOrderAsync(Order order)
        {
            try
            {
                using SqlConnection connection = new(constring);
                await connection.OpenAsync();

                string query = "UPDATE Orders SET CustomerName=@CustomerName, ProductCode=@ProductCode, Quantity=@Quantity, TotalPrice=@TotalPrice WHERE OrderID=@OrderID";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@OrderID", order.OrderID);
                command.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                command.Parameters.AddWithValue("@ProductCode", order.ProductCode);
                command.Parameters.AddWithValue("@Quantity", order.Quantity);
                command.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);

                int rows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"{rows} order(s) updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating order in database");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            try
            {
                using SqlConnection connection = new(constring);
                await connection.OpenAsync();

                string query = "DELETE FROM Orders WHERE OrderID = @OrderID";

                using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);

                int rows = await command.ExecuteNonQueryAsync();
                Console.WriteLine($"{rows} order(s) deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting order from database");
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var orders = new List<Order>();

            try
            {
                using SqlConnection connection = new(constring);
                await connection.OpenAsync();

                string query = "SELECT OrderID, CustomerName, ProductCode, Quantity, TotalPrice FROM Orders";

                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    orders.Add(new Order(
                        Convert.ToInt32(reader["OrderID"]),
                        reader["CustomerName"].ToString(),
                        reader["ProductCode"].ToString(),
                        Convert.ToInt32(reader["Quantity"]),
                        Convert.ToDecimal(reader["TotalPrice"])
                    ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading orders from database");
                Console.WriteLine(ex.Message);
            }

            return orders;
        }
    }
}
