using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests
{
    public class DeleteBookOrderRequest
    {
        public Guid BookOrderId { get; set; }

        public DeleteBookOrderRequest(Guid bookOrderId)
        {
            BookOrderId = bookOrderId;
        }
    }
}
