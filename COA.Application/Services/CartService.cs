using CustomerOrderService.Application.DTOs;
using CustomerOrderService.Application.Interfaces;
using CustomerOrderService.Domain.Entities;
using CustomerOrderService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerOrderService.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Cart>> GetCartAsync(Guid userId)
        {
            return await _cartRepository.GetByUserIdAsync(userId);
        }

        public async Task AddToCartAsync(CartDto cartDto)
        {
            if (cartDto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0");

            var product = await _productRepository.GetByIdAsync(cartDto.ProductId);
            if (product == null || !product.IsActive)
                throw new ArgumentException("Product not found or inactive");

            var now = DateTime.UtcNow;
            var existingCart = await _cartRepository.GetByUserIdAndProductIdAsync(cartDto.UserId, cartDto.ProductId);
            if (existingCart != null)
            {
                existingCart.Quantity += cartDto.Quantity;
                existingCart.UpdatedAt = now;
                await _cartRepository.UpdateAsync(existingCart);
            }
            else
            {
                var cart = new Cart
                {
                    UserId = cartDto.UserId,
                    ProductId = cartDto.ProductId,
                    Quantity = cartDto.Quantity,
                    CreatedAt = now
                };
                await _cartRepository.AddAsync(cart);
            }
        }
    }
}