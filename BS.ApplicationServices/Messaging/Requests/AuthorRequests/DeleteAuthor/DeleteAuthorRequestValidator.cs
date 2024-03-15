using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests.DeleteAuthor
{
    public class DeleteAuthorRequestValidator : AbstractValidator<DeleteAuthorRequest>
    {
        public DeleteAuthorRequestValidator()
        {
            RuleFor(x=>x.AuthorId).NotEmpty();
        }
    }
}
