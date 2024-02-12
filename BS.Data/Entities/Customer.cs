﻿using System.ComponentModel.DataAnnotations;

namespace BS.Data.Entities
{
    public class Customer
    {
        [Key]
        public required Guid CustomerId { get; set; }

        [StringLength(20)]
        public required string FirstName {  get; set; }

        [StringLength(20)]
        public required string LastName { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(10)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool hasOrders { get; set; }

        public int OrdersCount { get; set; }
    }
}