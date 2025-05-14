using CustomerOrderService.Application.Interfaces;
using CustomerOrderService.Domain.Entities;
using CustomerOrderService.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }
    }
}