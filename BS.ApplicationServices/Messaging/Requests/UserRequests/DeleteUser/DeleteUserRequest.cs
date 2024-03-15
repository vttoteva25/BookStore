namespace BS.ApplicationServices.Messaging.Requests.UserRequests.DeleteUser
{
    public class DeleteUserRequest
    {
        public Guid UserId { get; set; }

        public DeleteUserRequest(Guid userId)
        {
            UserId = userId;
        }
    }
}
