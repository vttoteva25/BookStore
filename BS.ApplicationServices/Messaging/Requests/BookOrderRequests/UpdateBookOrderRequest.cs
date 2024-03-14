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
        public Guid BookId { get; set; }

        public Guid OrderId { get; set; }

        public BookOrderVM? BookOrder { get; set; }

        public UpdateBookOrderRequest(Guid bookId, Guid orderId,BookOrderVM bookOrder) 
        {
            BookId = bookId;
            OrderId = orderId;
            BookOrder = bookOrder;
        }
    }
}
