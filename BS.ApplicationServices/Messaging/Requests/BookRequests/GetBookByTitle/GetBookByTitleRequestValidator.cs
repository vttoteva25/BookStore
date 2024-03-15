
using FluentValidation;

namespace BS.ApplicationServices.Messaging.Requests.BookRequests.GetBookByTitle
{
    public class GetBookByTitleRequestValidator : AbstractValidator<GetBookByTitleRequest>
    {
        public GetBookByTitleRequestValidator()
        {
            RuleFor(x=>x.Title).NotEmpty();
        }
    }
}
