using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class CreateCustomerRequest
    {
        public CustomerVM Customer { get; set; }

        public CreateCustomerRequest(CustomerVM customer)
        {
            Customer = customer;
        }
    }
}
