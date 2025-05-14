using CustomerOrderService.Domain.Entities;
using CustomerOrderService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderServiceDbContext _context;

        public OrderRepository(OrderServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.ShippingAddress)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.ShippingAddress)
                .Include(o => o.OrderItems)
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}