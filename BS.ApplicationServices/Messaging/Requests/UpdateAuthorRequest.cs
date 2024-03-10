﻿using BS.ApplicationServices.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.Messaging.Requests
{
    public class UpdateAuthorRequest
    {
        public Guid AuthorId { get; set; }

        public AuthorVM Author {  get; set; }
    }
}