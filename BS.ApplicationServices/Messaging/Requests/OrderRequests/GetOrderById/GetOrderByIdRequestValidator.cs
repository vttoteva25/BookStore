using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.OrderRequests.GetOrderById
{
    public class GetOrderByIdRequestValidator : AbstractValidator<GetOrderByIdRequest>
    {
        public GetOrderByIdRequestValidator() 
        { 
            RuleFor(x=>x.OrderId).NotEmpty();
        }
    }
}
