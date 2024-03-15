using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.UserRequests.GetUserById
{
    public class GetUserByIdRequestValidator : AbstractValidator<GetUserByIdRequest>
    {
        public GetUserByIdRequestValidator() 
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
