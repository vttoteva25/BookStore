using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.BookRequests.DeleteBook
{
    public class DeleteBookRequestValidator : AbstractValidator<DeleteBookRequest>
    {
        public DeleteBookRequestValidator()
        {
            RuleFor(x=>x.BookId).NotEmpty();
        }
    }
}
