using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests
{
    public class GetOrderByIdRequest
    {
        public Guid OrderId { get; set; }

        public GetOrderByIdRequest(Guid orderId) 
        {
            OrderId = orderId;
        }
    }
}
