
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

            RuleFor(x => x.Book.Title).MaximumLength(50);
            RuleFor(x => x.Book.Genre).MaximumLength(50);
            RuleFor(x => x.Book.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Book.ISBN).MaximumLength(20);
            RuleFor(x => x.Book.Language).MaximumLength(20);
            RuleFor(x => x.Book.QuantityAvailable).GreaterThanOrEqualTo(0);
        }
    }
}
