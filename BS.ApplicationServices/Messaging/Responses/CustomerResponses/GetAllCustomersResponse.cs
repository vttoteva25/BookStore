using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.CustomerResponse
{
    public class GetAllCustomersResponse : ServiceResponseBase
    {
        public List<CustomerVM> Customers { get; set; }
    }
}
