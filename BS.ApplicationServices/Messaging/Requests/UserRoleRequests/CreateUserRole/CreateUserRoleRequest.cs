using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.UserRoleRequests.CreateUserRoleRequestValidator
{
    public class CreateUserRoleRequest
    {
        public UserRoleVM UserRole { get; set; }

        public CreateUserRoleRequest(UserRoleVM userRole)
        {
            UserRole = userRole;
        }
    }
}
