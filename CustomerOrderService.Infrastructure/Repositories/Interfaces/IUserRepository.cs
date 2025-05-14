using CustomerOrderService.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CustomerOrderService.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByIdAsync(Guid userId);
        Task AddAsync(User user);
    }
}