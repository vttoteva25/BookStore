namespace BS.ApplicationServices.Messaging.Requests.UserRequests
{
    public class DeleteUserRequest
    {
        public Guid UserId { get; set; }
        
        public DeleteUserRequest(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
