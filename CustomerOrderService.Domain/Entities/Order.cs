using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrderService.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public Guid UserId { get; set; } 
        public User User { get; set; } 
        [Required, StringLength(100)]
        public string CustomerName { get; set; }
        [Required, StringLength(100), EmailAddress]
        public string CustomerEmail { get; set; }
        public int ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }
        [Required, StringLength(50)]
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}