using CustomerOrderService.Domain.Entities;
using System.Threading.Tasks;

namespace CustomerOrderService.Infrastructure.Repositories
{
    public interface IAddressRepository
    {
        Task AddAsync(Address address);
    }
}