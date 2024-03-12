namespace BS.ApplicationServices.Messaging.Requests.BookRequests
{
    public class GetBookByTitleRequest
    {
        public string Title { get; set; }

        public GetBookByTitleRequest(string title)
        {
            Title = title;
        }
    }
}
