using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.ViewModels
{
    public class CustomerVM
    {
        public required Guid CustomerId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool hasOrders { get; set; }

        public int OrdersCount { get; set; }
    }
}
