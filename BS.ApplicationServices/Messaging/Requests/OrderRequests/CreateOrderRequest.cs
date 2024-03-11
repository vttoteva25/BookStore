using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests
{
    public class CreateOrderRequest
    {
        public OrderVM? Order { get; set; }

        public CreateOrderRequest(OrderVM? order)
        {
            Order = order;
        }
    }
}
