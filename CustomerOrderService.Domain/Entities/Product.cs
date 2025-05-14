using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerOrderService.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [StringLength(500)]
        public string ImageUrl { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } // Removed dynamic initializer
        public DateTime? UpdatedAt { get; set; }
    }
}