using BS.ApplicationServices.Messaging.Requests.BookOrderRequests.CreateBookOrder;
using BS.ApplicationServices.Messaging.Requests.UserRequests.CreateUser;
using BS.ApplicationServices.Messaging.Requests.UserRoleRequests.CreateUserRoleRequestValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.UserRoleRequests.CreateUserRole
{
    public class CreateUserRoleRequestValidator : AbstractValidator<CreateUserRoleRequest>
    {
        public CreateUserRoleRequestValidator()
        {

            RuleFor(x => x.UserRole).NotEmpty();
            RuleFor(x => x.UserRole.UserId).NotEmpty();
            RuleFor(x => x.UserRole.RoleId).NotEmpty();
        }
    }
}
