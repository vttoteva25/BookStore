using BS.ApplicationServices.ViewModels.CustomerVM;

namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class CreateCustomerRequest
    {
        public RegisterCustomerVM Customer { get; set; }

        public CreateCustomerRequest(RegisterCustomerVM customer)
        {
            Customer = customer;
        }
    }
}
