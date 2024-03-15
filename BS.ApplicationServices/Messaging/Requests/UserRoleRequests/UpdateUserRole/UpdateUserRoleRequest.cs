using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.UserRoleRequests.UpdateUserRole
{
    public class UpdateUserRoleRequest
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public UserRoleVM? UserRole { get; set; }

        public UpdateUserRoleRequest(Guid userId, Guid roleId, UserRoleVM? useRole)
        {
            UserId = userId;
            RoleId = roleId;
            UserRole = useRole;
        }
    }
}
