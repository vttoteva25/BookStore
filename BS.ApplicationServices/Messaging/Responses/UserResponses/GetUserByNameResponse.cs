﻿using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.UserResponse
{
    public class GetUserByNameResponse : ServiceResponseBase
    {
        public List<UserVM>? Users { get; set; }

    }
}
