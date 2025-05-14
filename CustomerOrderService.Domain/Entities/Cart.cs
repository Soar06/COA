using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerOrderService.Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public Guid UserId { get; set; } 
        public User User { get; set; } 
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}