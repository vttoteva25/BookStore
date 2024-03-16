using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests.UpdateAuthor
{
    public class UpdateAuthorRequestValidator : AbstractValidator<UpdateAuthorRequest>
    {
        public UpdateAuthorRequestValidator() { 
            RuleFor(x => x.AuthorId).NotEmpty();
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.Author.FirstName).NotEmpty();
            RuleFor(x => x.Author.FirstName).MaximumLength(20);
            RuleFor(x => x.Author.LastName).MaximumLength(20);
            RuleFor(x => x.Author.Email).MaximumLength(50);
            RuleFor(x => x.Author.WrittenBooksCount).GreaterThanOrEqualTo(0);
        }
    }
}
