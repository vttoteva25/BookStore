using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests.GetAllOrdersByBookId
{
    public class GetAllOrdersByBookIdRequestValidator : AbstractValidator<GetAllOrdersByBookIdRequest>
    {
        public GetAllOrdersByBookIdRequestValidator() { 
            RuleFor(x=> x.BookId).NotEmpty();
        }
    }
}
