using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.RolesRequests.CreateRole
{
    public class CreateRoleRequest
    {
        public RoleVM Role { get; set; }

        public CreateRoleRequest(RoleVM role)
        {
            Role = role;
        }
    }
}
