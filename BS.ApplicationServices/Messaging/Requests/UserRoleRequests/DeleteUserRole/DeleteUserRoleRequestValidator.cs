using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.CreateUserRoleRequestValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.UserRoleRequests.DeleteUserRole
{
    public class DeleteUserRoleRequestValidator : AbstractValidator<DeleteUserRoleRequest>
    {
        public DeleteUserRoleRequestValidator()
        {

            RuleFor(x => x.UserRole).NotEmpty();
            RuleFor(x => x.UserRole.UserId).NotEmpty();
            RuleFor(x => x.UserRole.RoleId).NotEmpty();
        }
    }
}
