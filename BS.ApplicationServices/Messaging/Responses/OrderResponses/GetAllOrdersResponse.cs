using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.OrderResponses
{
    public class GetAllOrdersResponse:ServiceResponseBase
    {
        public List<OrderVM> Orders { get; set; }
    }
}
