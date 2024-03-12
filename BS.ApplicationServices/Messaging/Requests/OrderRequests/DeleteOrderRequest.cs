using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests
{
    public class DeleteOrderRequest
    {
        public Guid OrderId { get; set;}

        public DeleteOrderRequest(Guid orderId) 
        {
            OrderId = orderId;
        }
    }
}
