using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.CustomerResponses
{
    public class AuthenticateResponse : ServiceResponseBase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        
    }
}
