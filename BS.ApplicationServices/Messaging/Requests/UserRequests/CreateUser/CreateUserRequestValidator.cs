using FluentValidation;
using XAct;

namespace BS.ApplicationServices.Messaging.Requests.UserRequests.CreateUser
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator() 
        { 
            RuleFor(x => x.User.FirstName).NotEmpty();
            RuleFor(x => x.User.LastName).NotEmpty();
            RuleFor(x => x.User.Username).NotEmpty(); 
            RuleFor(x => x.User.Password).NotEmpty();

            RuleFor(x => x.User.FirstName).MaximumLength(20);
            RuleFor(x => x.User.LastName).MaximumLength(20);
            RuleFor(x => x.User.Username).MaximumLength(50);
            RuleFor(x => x.User.Password).MaximumLength(50);
            RuleFor(x => x.User.Phone).MaximumLength(10);
            RuleFor(x => x.User.Address).MaximumLength(100);
            RuleFor(x => x.User.Email).MaximumLength(50).EmailAddress();

        }
    }
}
