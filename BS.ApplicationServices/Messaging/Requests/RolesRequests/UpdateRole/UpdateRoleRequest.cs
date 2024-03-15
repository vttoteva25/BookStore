using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.RolesRequests.UpdateRole
{
    public class UpdateRoleRequest
    {
        public Guid RoleId { get; set; }

        public RoleVM Role { get; set; }

        public UpdateRoleRequest(Guid roleId, RoleVM role)
        {
            RoleId = roleId;
            Role = role;
        }
    }
}
