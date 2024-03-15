namespace BS.ApplicationServices.Messaging.Requests.BookRequests.DeleteBook
{
    public class DeleteBookRequest
    {
        public Guid BookId { get; set; }

        public DeleteBookRequest(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
