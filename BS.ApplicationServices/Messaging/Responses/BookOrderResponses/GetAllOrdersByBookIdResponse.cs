using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.BookOrderResponses
{
    public class GetAllOrdersByBookIdResponse:ServiceResponseBase
    {
        public List<OrderVM> Orders { get; set; }
    }
}
