using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests.DeleteOrder
{
    public class DeleteOrderRequestValidator : AbstractValidator<DeleteOrderRequest>
    {
        public DeleteOrderRequestValidator() 
        { 
            RuleFor(x=>x.OrderId).NotEmpty();
        }
    }
}
