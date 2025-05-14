using System;

namespace CustomerOrderService.Application.DTOs
{
    public class CartDto
    {
        public Guid UserId { get; set; } // Changed from string to Guid
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}