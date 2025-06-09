using OrderManagementSystem.Model;
using OrderManagementSystem.Repository;
using OrderManagementSystem.Service;

namespace OrderManagementSystem
{
    internal class Program
    {
            static async Task Main(string[] args)
            {
                IOrderRepository repo = new OrderRepositoryImpl();
                IOrderService service = new OrderServiceImpl(repo);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("E-Commerce Order Management System");
                    Console.WriteLine("1. Add Order");
                    Console.WriteLine("2. Update Order");
                    Console.WriteLine("3. Delete Order");
                    Console.WriteLine("4. List All Orders");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            await AddOrderInput(service);
                            break;
                        case "2":
                            await UpdateOrderInput(service);
                            break;
                        case "3":
                            await DeleteOrderInput(service);
                            break;
                        case "4":
                            await DisplayAllOrders(service);
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Press any key to try again...");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            private static async Task AddOrderInput(IOrderService service)
            {
                Console.WriteLine("\nEnter Order Details:");

                // OrderID is auto-generated in DB, so no input here

                Console.Write("Customer Name: ");
                string customerName = Console.ReadLine();

                Console.Write("Product Code: ");
                string productCode = Console.ReadLine();

                Console.Write("Quantity: ");
                int.TryParse(Console.ReadLine(), out int quantity);

                Console.Write("Total Price: ");
                decimal.TryParse(Console.ReadLine(), out decimal totalPrice);

                Order order = new Order(0, customerName, productCode, quantity, totalPrice);
                await service.AddOrderServiceAsync(order);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static async Task UpdateOrderInput(IOrderService service)
            {
                Console.WriteLine("\nUpdate Order Details:");

                Console.Write("Order ID to update: ");
                int.TryParse(Console.ReadLine(), out int orderId);

                Console.Write("New Customer Name: ");
                string customerName = Console.ReadLine();

                Console.Write("New Product Code: ");
                string productCode = Console.ReadLine();

                Console.Write("New Quantity: ");
                int.TryParse(Console.ReadLine(), out int quantity);

                Console.Write("New Total Price: ");
                decimal.TryParse(Console.ReadLine(), out decimal totalPrice);

                Order order = new Order(orderId, customerName, productCode, quantity, totalPrice);
                await service.UpdateOrderServiceAsync(order);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static async Task DeleteOrderInput(IOrderService service)
            {
                Console.WriteLine("\nDelete Order:");

                Console.Write("Enter Order ID to delete: ");
                int.TryParse(Console.ReadLine(), out int orderId);

                await service.DeleteOrderServiceAsync(orderId);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static async Task DisplayAllOrders(IOrderService service)
            {
                Console.WriteLine("\nList of Orders:");

                List<Order> orders = await service.GetAllOrdersServiceAsync();

                if (orders.Count == 0)
                {
                    Console.WriteLine("No orders found.");
                }
                else
                {
                    Console.WriteLine("{0,-8} | {1,-20} | {2,-15} | {3,-8} | {4,12}", "OrderID", "CustomerName", "ProductCode", "Quantity", "TotalPrice");
                    Console.WriteLine(new string('-', 70));

                    foreach (var order in orders)
                    {
                        Console.WriteLine("{0,-8} | {1,-20} | {2,-15} | {3,-8} | {4,12:C2}",
                            order.OrderID, order.CustomerName, order.ProductCode, order.Quantity, order.TotalPrice);
                    }
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    
}
