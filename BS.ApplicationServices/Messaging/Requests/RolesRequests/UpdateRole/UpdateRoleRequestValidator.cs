using BS.ApplicationServices.Messaging.Requests.BookRequests.UpdateBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.RolesRequests.UpdateRole
{
    public class UpdateRoleRequestValidator : AbstractValidator<UpdateRoleRequest>
    {
        public UpdateRoleRequestValidator()
        {
            RuleFor(x => x.Role.RoleId).NotEmpty();
            RuleFor(x => x.Role.RoleName).NotEmpty();
        }
    }
}
