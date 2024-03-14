using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BS.Data.Entities
{
    public class Order
    {
        [Key]
        public required Guid OrderId { get; set; }

        [ForeignKey("Customer Id")]
        public required Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        [Range(0.00, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        [StringLength(20)]
        public string? PaymentMethod { get; set; }

        [StringLength(20)]
        public string? DeliveryAddress { get; set; }

        [StringLength(20)]
        public string? DeliveryStatus { get; set; }

        public bool IsApproved { get; set; } = false;

        public bool IsDelivered { get; set; } = false;

        public User Customer { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
