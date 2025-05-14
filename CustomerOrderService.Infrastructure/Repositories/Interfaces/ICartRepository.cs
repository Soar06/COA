using CustomerOrderService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Infrastructure.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetByUserIdAsync(string userId);
        Task<Cart> GetByUserIdAndProductIdAsync(string userId, int productId);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteByUserIdAsync(string userId);
    }
}