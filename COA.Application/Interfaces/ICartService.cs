using CustomerOrderService.Application.DTOs;
using CustomerOrderService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Application.Interfaces
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetCartAsync(string userId);
        Task AddToCartAsync(CartDto cartDto);
    }
}