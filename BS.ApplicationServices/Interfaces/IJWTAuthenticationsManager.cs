using BS.Data.Entities;

namespace BS.ApplicationServices.Interfaces
{
    public interface IJWTAuthenticationsManager
    {
        string? GenerateJwtToken(User user);
    }
}
