using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.CustomerResponse
{
    public class GetCustomerByNameResponse:ServiceResponseBase
    {
        public CustomerVM? Customer { get; set; }

    }
}
