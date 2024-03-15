using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests.CreateOrder
{
    public class CreateOrderRequestValidator: AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator() 
        { 
            RuleFor(x=> x.Order.UserId).NotEmpty();
            RuleFor(x=> x.Order.DeliveryAddress).NotEmpty();
            RuleFor(x=> x.Order.PaymentMethod).NotEmpty();
            RuleFor(x=> x.Order.TotalAmount).NotEmpty();
        }
    }
}
