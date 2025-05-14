using CustomerOrderService.Application.DTOs;
using CustomerOrderService.Application.Interfaces;
using CustomerOrderService.Domain.Entities;
using CustomerOrderService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrderService.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IAddressRepository _addressRepository;

        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, IAddressRepository addressRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _addressRepository = addressRepository;
        }

        public async Task<int> CreateOrderAsync(OrderDto orderDto)
        {
            var cartItems = await _cartRepository.GetByUserIdAsync(orderDto.UserId);
            if (!cartItems.Any())
                throw new InvalidOperationException("Cart is empty");

            var now = DateTime.UtcNow;
            var address = new Address
            {
                AddressLine = orderDto.AddressLine,
                City = orderDto.City,
                Country = orderDto.Country,
                PostalCode = orderDto.PostalCode,
                CreatedAt = now
            };
            await _addressRepository.AddAsync(address);

            var order = new Order
            {
                UserId = orderDto.UserId,
                CustomerName = orderDto.CustomerName,
                CustomerEmail = orderDto.CustomerEmail,
                ShippingAddressId = address.AddressId,
                TotalAmount = cartItems.Sum(c => c.Quantity * c.Product.Price),
                Status = "Pending",
                CreatedAt = now
            };

            foreach (var cartItem in cartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price,
                    CreatedAt = now
                });
            }

            await _orderRepository.AddAsync(order);
            await _cartRepository.DeleteByUserIdAsync(orderDto.UserId);

            // TODO: Send email confirmation (e.g., via SendGrid)
            return order.OrderId;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new KeyNotFoundException("Order not found");
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new KeyNotFoundException("Order not found");

            order.Status = status;
            order.UpdatedAt = DateTime.UtcNow;
            await _orderRepository.UpdateAsync(order);
        }
    }
}