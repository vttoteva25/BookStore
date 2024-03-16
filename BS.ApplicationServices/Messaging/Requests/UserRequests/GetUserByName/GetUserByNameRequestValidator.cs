using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.UserRequests.GetUserByName
{
    public class GetUserByNameRequestValidator : AbstractValidator<GetUserByNameRequest>
    {
        public GetUserByNameRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.FirstName).MaximumLength(20);
            RuleFor(x => x.LastName).MaximumLength(20);
        }
    }
}
