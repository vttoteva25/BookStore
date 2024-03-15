using BS.ApplicationServices.Messaging.Requests.BookOrderRequests.GetAllBooksByOrderId;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.UserRoleRequests.GetAllRolesByUserId
{
    public class GetAllRolesByUserIdRequestValidator : AbstractValidator<GetAllRolesByUserIdRequest>
    {
        public GetAllRolesByUserIdRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
