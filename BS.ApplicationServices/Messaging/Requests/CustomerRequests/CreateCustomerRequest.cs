using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
