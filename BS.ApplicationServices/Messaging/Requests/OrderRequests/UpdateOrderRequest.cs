using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests
{
    public class UpdateOrderRequest
    {
        public Guid OrderId { get; set;}

        public OrderVM? Order { get; set; }

        public UpdateOrderRequest(Guid orderId, OrderVM? order)
        {
            OrderId = orderId;
            Order = order;
        }
    }
}
