namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class GetUserByIdRequest
    {
        public Guid UserId { get; set; }

        public GetUserByIdRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
