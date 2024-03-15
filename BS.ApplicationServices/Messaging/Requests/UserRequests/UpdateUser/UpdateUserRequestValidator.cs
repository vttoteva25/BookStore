using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.UserRequests.UpdateUser
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator() 
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.User).NotEmpty();
            RuleFor(x => x.User.FirstName).NotEmpty();
            RuleFor(x => x.User.LastName).NotEmpty();
            RuleFor(x => x.User.Username).NotEmpty();
            RuleFor(x => x.User.Password).NotEmpty();
        }
    }
}
