using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.RolesResponses
{
    public class GetAllRolesResponse : ServiceResponseBase
    {
        public List<RoleVM> Roles { get; set; }
    }
}
