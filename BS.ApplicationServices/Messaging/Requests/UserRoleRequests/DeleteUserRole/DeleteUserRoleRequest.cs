using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.UserRoleRequests.DeleteUserRole
{
    public class DeleteUserRoleRequest
    {
        public UserRoleVM UserRole { get; set; }

        public DeleteUserRoleRequest(UserRoleVM userRole)
        {
            UserRole = userRole;
        }
    }
}
