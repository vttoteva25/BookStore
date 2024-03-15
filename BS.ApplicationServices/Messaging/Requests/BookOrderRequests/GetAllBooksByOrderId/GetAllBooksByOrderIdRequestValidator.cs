using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests.GetAllBooksByOrderId
{
    public class GetAllBooksByOrderIdRequestValidator : AbstractValidator<GetAllBooksByOrderIdRequest>
    {
        public GetAllBooksByOrderIdRequestValidator()
        {
            RuleFor(x=>x.OrderId).NotEmpty();
        }
    }
}
