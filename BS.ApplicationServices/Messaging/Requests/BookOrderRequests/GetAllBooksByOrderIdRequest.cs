using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests
{
    public class GetAllBooksByOrderIdRequest
    {
        public Guid OrderId { get; set; }

        public GetAllBooksByOrderIdRequest(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
