using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests.CreateBookOrder
{
    public class CreateBookOrderRequest
    {
        public BookOrderVM BookOrder { get; set; }

        public CreateBookOrderRequest(BookOrderVM bookOrderVM)
        {
            BookOrder = bookOrderVM;
        }
    }
}
