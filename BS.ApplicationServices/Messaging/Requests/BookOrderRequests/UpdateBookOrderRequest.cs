using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests
{
    public class UpdateBookOrderRequest
    {
        public Guid BookOrderId { get; set; }

        public BookOrderVM? BookOrder { get; set; }

        public UpdateBookOrderRequest(Guid bookOrderId, BookOrderVM bookOrder) 
        {
            BookOrderId = bookOrderId;
            BookOrder = bookOrder;
        }
    }
}
