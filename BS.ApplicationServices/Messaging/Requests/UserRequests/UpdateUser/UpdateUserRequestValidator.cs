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
