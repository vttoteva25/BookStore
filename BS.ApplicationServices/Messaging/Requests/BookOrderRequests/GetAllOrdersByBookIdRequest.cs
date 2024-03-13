using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests
{
    public class GetAllOrdersByBookIdRequest
    {
        public Guid BookId { get; set; }

        public GetAllOrdersByBookIdRequest(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
