using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.BookRequests.CreateBook
{
    public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidator() 
        { 
            RuleFor(x=> x.Book.Genre).NotEmpty();
            RuleFor(x=> x.Book.Title).NotEmpty();
            RuleFor(x=> x.Book.ISBN).NotEmpty();
        }
    }
}
