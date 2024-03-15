namespace BS.ApplicationServices.Messaging.Requests.UserRequests.GetUserById
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
