﻿using BS.ApplicationServices.ViewModels;

namespace BS.ApplicationServices.Messaging.Responses.CustomerResponse
{
    public class GetCustomerByNameResponse : ServiceResponseBase
    {
        public UserVM? User { get; set; }

    }
}
