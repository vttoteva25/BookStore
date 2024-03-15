using BS.ApplicationServices.Messaging.Requests.BookRequests.GetBookByTitle;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.RolesRequests.GetRoleByName
{
    public class GetRoleByNameRequestValidator : AbstractValidator<GetRoleByNameRequest>
    {
        public GetRoleByNameRequestValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty();
        }
    }
}
