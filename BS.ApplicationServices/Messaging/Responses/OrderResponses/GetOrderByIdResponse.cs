using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.OrderResponses
{
    public class GetOrderByIdResponse:ServiceResponseBase
    {
        public OrderVM? Order { get; set; }
    }
}
