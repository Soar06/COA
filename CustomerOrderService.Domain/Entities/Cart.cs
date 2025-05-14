using System.ComponentModel.DataAnnotations;

namespace CustomerOrderService.Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        [Required, StringLength(50)]
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } // Removed dynamic initializer
        public DateTime? UpdatedAt { get; set; }
    }
}