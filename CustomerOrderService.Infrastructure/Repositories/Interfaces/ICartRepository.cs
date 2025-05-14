using CustomerOrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Infrastructure.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetByUserIdAsync(Guid userId);
        Task<Cart> GetByUserIdAndProductIdAsync(Guid userId, int productId);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteByUserIdAsync(Guid userId);
    }
}