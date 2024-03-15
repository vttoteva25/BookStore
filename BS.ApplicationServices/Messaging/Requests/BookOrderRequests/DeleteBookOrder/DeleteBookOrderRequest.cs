using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests.DeleteBookOrder
{
    public class DeleteBookOrderRequest
    {
        public BookOrderVM BookOrder { get; set; }

        public DeleteBookOrderRequest(BookOrderVM bookOrder)
        {
            BookOrder = bookOrder;
        }
    }
}
