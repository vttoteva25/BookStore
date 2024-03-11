using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class DeleteCustomerRequest
    {
        public Guid CustomerId { get; set; }
        
        public DeleteCustomerRequest(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
