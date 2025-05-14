using System;

namespace CustomerOrderService.Application.DTOs
{
    public class OrderDto
    {
        public Guid UserId { get; set; } // Changed from string to Guid
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}