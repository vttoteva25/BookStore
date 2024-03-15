using FluentValidation;


namespace BS.ApplicationServices.Messaging.Requests.UserRequests.AuthenticateUser
{
    public class AuthenticateUserRequestValidator : AbstractValidator<AuthenticateUserRequest>
    {
        public AuthenticateUserRequestValidator() 
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
