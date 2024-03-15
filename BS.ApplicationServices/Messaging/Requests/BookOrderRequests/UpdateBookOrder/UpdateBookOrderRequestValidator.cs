using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests.UpdateBookOrder
{
    public class UpdateBookOrderRequestValidator : AbstractValidator<UpdateBookOrderRequest>
    {
        public UpdateBookOrderRequestValidator() { 
            RuleFor(x=>x.OrderId).NotEmpty();
            RuleFor(x=>x.OrderId).NotEmpty();
        }
    }
}
