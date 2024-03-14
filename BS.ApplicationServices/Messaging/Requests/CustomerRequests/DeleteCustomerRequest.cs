﻿namespace BS.ApplicationServices.Messaging.Requests.CustomerRequests
{
    public class DeleteCustomerRequest
    {
        public Guid UserId { get; set; }
        
        public DeleteCustomerRequest(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
