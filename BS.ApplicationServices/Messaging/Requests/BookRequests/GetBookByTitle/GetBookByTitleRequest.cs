namespace BS.ApplicationServices.Messaging.Requests.BookRequests.GetBookByTitle
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
