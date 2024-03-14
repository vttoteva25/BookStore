using System.Text.Json.Serialization;

namespace BS.ApplicationServices.ViewModels
{
    public class UserVM : BaseUserVM
    {
        public required Guid UserId { get; set; }        

        public DateTime RegistrationDate { get; set; }

        public bool HasOrders { get; set; }

        public int OrdersCount { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
