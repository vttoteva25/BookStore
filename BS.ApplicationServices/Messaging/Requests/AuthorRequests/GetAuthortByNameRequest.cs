﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests.AuthorRequests
{
    public class GetAuthortByNameRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public GetAuthortByNameRequest(string? firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
