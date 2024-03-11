﻿namespace BS.ApplicationServices.Interfaces
{
    public interface IJWTAuthenticationsManager
    {
        string? Authenticate(string clientId, string secret);
    }
}
