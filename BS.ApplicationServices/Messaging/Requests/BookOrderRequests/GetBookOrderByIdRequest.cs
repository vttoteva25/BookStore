using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests
{
    public class GetBookOrderByIdRequest
    {
        public Guid BookOrderId { get; set; }

        public GetBookOrderByIdRequest(Guid bookOrderId) 
        {
            BookOrderId = bookOrderId;
        }
    }
}
