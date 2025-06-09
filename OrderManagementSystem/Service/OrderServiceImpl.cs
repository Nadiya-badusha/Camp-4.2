using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Model;
using OrderManagementSystem.Repository;

namespace OrderManagementSystem.Service
{
    public class OrderServiceImpl : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderServiceImpl(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddOrderServiceAsync(Order order)
        {
            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderServiceAsync(Order order)
        {
            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderServiceAsync(int orderId)
        {
            await _orderRepository.DeleteOrderAsync(orderId);
        }

        public async Task<List<Order>> GetAllOrdersServiceAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }
    }
}
