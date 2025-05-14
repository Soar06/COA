using CustomerOrderService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int orderId);
        Task<IEnumerable<Order>> GetAllAsync();
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }
}