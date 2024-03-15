using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests.DeleteBookOrder
{
    public class DeleteBookOrderRequestValidator : AbstractValidator<DeleteBookOrderRequest>
    {
        public DeleteBookOrderRequestValidator()
        {
            RuleFor(x=> x.BookOrder).NotEmpty();
            RuleFor(x=> x.BookOrder.OrderId).NotEmpty();
            RuleFor(x=> x.BookOrder.BookId).NotEmpty();
        }
    }
}
