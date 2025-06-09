using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Model;

namespace OrderManagementSystem.Service
{
    public interface IOrderService
    {
        Task AddOrderServiceAsync(Order order);
        Task UpdateOrderServiceAsync(Order order);
        Task DeleteOrderServiceAsync(int orderId);
        Task<List<Order>> GetAllOrdersServiceAsync();
    }
}
