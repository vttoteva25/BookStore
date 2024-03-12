using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
