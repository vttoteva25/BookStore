using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.RolesRequests.DeleteRole
{
    public class DeleteRoleRequest
    {
        public Guid RoleId { get; set; }

        public DeleteRoleRequest(Guid roleId)
        {
            RoleId = roleId;
        }
    }
}
