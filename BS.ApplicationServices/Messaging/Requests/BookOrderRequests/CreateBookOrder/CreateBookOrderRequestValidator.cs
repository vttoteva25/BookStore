
using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests.CreateBookOrder
{
    public class CreateBookOrderRequestValidator : AbstractValidator<CreateBookOrderRequest>
    {
        public CreateBookOrderRequestValidator() { 

            RuleFor(x=>x.BookOrder).NotEmpty();
            RuleFor(x=>x.BookOrder.OrderId).NotEmpty();
            RuleFor(x=>x.BookOrder.BookId).NotEmpty();
        }
    }
}
