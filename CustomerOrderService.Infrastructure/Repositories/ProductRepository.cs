using CustomerOrderService.Domain.Entities;
using CustomerOrderService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderServiceDbContext _context;

        public ProductRepository(OrderServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == productId && p.IsActive);
        }
    }
}