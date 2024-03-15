using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Responses.RolesResponses
{
    public class GetRoleByNameResponse : ServiceResponseBase
    {
        public RoleVM Role { get; set; }
    }
}
