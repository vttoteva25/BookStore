using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Requests.BookOrderRequests.UpdateBookOrder
{
    public class UpdateBookOrderRequest
    {
        public Guid BookId { get; set; }

        public Guid OrderId { get; set; }

        public BookOrderVM? BookOrder { get; set; }

        public UpdateBookOrderRequest(Guid bookId, Guid orderId, BookOrderVM bookOrder)
        {
            BookId = bookId;
            OrderId = orderId;
            BookOrder = bookOrder;
        }
    }
}
