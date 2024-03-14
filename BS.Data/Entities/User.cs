using System.ComponentModel.DataAnnotations;

namespace BS.Data.Entities
{
    public class User
    {
        [Key]
        public required Guid UserId { get; set; }

        [StringLength(20)]
        public required string FirstName {  get; set; }

        [StringLength(20)]
        public required string LastName { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(50)]
        public required string Username {  get; set; }

        [StringLength(50)]
        public required string Password { get; set; }

        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool HasOrders { get; set; } = false;

        public int OrdersCount { get; set; } = 0;

        public ICollection<Role> Roles { get; set; }
    }
}
