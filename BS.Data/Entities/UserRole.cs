using System.ComponentModel.DataAnnotations.Schema;

namespace BS.Data.Entities
{
    public class UserRole
    {
        [ForeignKey("User Id")]
        public required Guid UserId { get; set; }

        [ForeignKey("Role Id")]
        public required Guid RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
