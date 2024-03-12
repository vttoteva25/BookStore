using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class UpdateCustomerRequest
    {
        public Guid CustomerId { get; set; }

        public CustomerVM? Customer { get; set; }

        public UpdateCustomerRequest(Guid customerId, CustomerVM customer)
        {
            CustomerId = customerId;
            Customer = customer;
        }
    }
}
