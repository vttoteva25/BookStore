using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.UserRoleResponses
{
    public class GetAllUsersByRoleIdResponse: ServiceResponseBase
    {
        public List<UserVM> Users{ get; set; }
    }
}
