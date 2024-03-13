using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.BookOrderResponses
{
    public class GetAllBookOrdersResponse:ServiceResponseBase
    {
        public List<BookOrderVM>? BookOrders { get; set; }
    }
}
