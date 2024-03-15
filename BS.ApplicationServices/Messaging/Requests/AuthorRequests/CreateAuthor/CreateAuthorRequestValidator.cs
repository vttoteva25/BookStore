using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests.CreateAuthor
{
    public class CreateAuthorRequestValidator : AbstractValidator<CreateAuthorRequest>
    {
        public CreateAuthorRequestValidator() 
        {
            RuleFor(x=> x.Author.FirstName).NotEmpty();
        }
    }
}
