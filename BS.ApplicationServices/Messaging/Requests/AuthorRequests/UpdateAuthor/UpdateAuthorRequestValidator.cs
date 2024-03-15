using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests.UpdateAuthor
{
    public class UpdateAuthorRequestValidator : AbstractValidator<UpdateAuthorRequest>
    {
        public UpdateAuthorRequestValidator() { 
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Author.FirstName).NotEmpty();
        }
    }
}
