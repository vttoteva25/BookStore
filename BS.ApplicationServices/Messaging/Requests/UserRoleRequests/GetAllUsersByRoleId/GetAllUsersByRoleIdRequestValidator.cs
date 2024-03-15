using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllRolesByUserId;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllUsersByRoleId
{
    public class GetAllUsersByRoleIdRequestValidator : AbstractValidator<GetAllUsersByRoleIdRequest>
    {
        public GetAllUsersByRoleIdRequestValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty();
        }
    }
}
