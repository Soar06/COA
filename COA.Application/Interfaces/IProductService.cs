using CustomerOrderService.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}