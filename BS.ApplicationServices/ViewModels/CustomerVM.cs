namespace BS.ApplicationServices.ViewModels
{
    public class CustomerVM
    {
        public required Guid CustomerId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool HasOrders { get; set; }

        public int OrdersCount { get; set; }
    }
}
