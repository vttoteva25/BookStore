namespace BS.ApplicationServices.ViewModels
{
    public class OrderVM
    {
        public required Guid OrderId { get; set; }

        public required Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string? PaymentMethod { get; set; }

        public string? DeliveryAddress { get; set; }

        public string? DeliveryStatus { get; set; }

        public bool IsApproved { get; set; } = false;

        public bool IsDelivered { get; set; } = false;

    }
}
