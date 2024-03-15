
using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests.GetAuthorByName
{
    public class GetAuthorByNameRequestValidator : AbstractValidator<GetAuthorByNameRequest>
    {
        public GetAuthorByNameRequestValidator() { 
            RuleFor(x=> x.FirstName).NotEmpty();
        }
    }
}
