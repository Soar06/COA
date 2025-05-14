using System.ComponentModel.DataAnnotations;

namespace CustomerOrderService.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required, StringLength(500)]
        public string AddressLine { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        [StringLength(20)]
        public string PostalCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}