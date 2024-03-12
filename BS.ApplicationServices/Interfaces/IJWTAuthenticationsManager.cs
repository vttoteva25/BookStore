using BS.Data.Entities;

namespace BS.ApplicationServices.Interfaces
{
    public interface IJWTAuthenticationsManager
    {
        string? Authenticate(Customer customer);
    }
}
