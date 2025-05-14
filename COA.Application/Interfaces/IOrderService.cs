using CustomerOrderService.Application.DTOs;
using CustomerOrderService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Application.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(OrderDto orderDto);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task UpdateOrderStatusAsync(int orderId, string status);
    }
}