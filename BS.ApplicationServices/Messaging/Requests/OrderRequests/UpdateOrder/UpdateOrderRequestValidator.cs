using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests.UpdateOrder
{
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.Order).NotEmpty();
            RuleFor(x => x.Order.UserId).NotEmpty();
            RuleFor(x => x.Order.DeliveryAddress).NotEmpty();
            RuleFor(x => x.Order.PaymentMethod).NotEmpty();
            RuleFor(x => x.Order.TotalAmount).NotEmpty();
        }
    }
}
