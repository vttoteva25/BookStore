
using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.BookRequests.UpdateBook
{
    public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookRequestValidator() { 
            RuleFor(x=> x.BookId).NotEmpty();
            RuleFor(x=> x.Book).NotEmpty();
            RuleFor(x => x.Book.Genre).NotEmpty();
            RuleFor(x => x.Book.Title).NotEmpty();
            RuleFor(x => x.Book.ISBN).NotEmpty();
        }
    }
}
