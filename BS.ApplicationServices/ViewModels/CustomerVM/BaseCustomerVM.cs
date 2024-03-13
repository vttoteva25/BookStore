namespace BS.ApplicationServices.ViewModels.CustomerVM
{
    public class BaseCustomerVM
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

    }
}
