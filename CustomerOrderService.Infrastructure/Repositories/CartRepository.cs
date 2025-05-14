using CustomerOrderService.Domain.Entities;
using CustomerOrderService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly OrderServiceDbContext _context;

        public CartRepository(OrderServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> GetByUserIdAsync(string userId)
        {
            return await _context.Carts
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task<Cart> GetByUserIdAndProductIdAsync(string userId, int productId)
        {
            return await _context.Carts
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);
        }

        public async Task AddAsync(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByUserIdAsync(string userId)
        {
            var carts = await _context.Carts
                .Where(c => c.UserId == userId)
                .ToListAsync();
            _context.Carts.RemoveRange(carts);
            await _context.SaveChangesAsync();
        }
    }
}