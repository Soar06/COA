using CustomerOrderService.Domain.Entities;
using CustomerOrderService.Infrastructure.Data;
using System.Threading.Tasks;

namespace CustomerOrderService.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly OrderServiceDbContext _context;

        public AddressRepository(OrderServiceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
        }
    }
}