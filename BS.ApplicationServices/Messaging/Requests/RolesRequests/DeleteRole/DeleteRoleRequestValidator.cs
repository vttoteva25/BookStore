using BS.ApplicationServices.Messaging.Requests.BookRequests.DeleteBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.RolesRequests.DeleteRole
{
    public class DeleteRoleRequestValidator : AbstractValidator<DeleteRoleRequest>
    {
        public DeleteRoleRequestValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty();
        }
    }
}
