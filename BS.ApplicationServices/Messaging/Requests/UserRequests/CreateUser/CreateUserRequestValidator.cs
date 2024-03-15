using FluentValidation;

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
        }
    }
}
