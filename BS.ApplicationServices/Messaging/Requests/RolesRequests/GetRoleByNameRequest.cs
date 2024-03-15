using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.RolesRequests
{
    public class GetRoleByNameRequest
    {
        public string RoleName { get; set; }

        public GetRoleByNameRequest(string roleName)
        {
            RoleName = roleName;
        }
    }
}
