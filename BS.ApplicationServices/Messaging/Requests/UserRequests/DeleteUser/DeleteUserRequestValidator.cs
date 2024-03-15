using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.UserRequests.DeleteUser
{
    public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserRequestValidator() 
        { 
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
