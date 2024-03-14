using System.ComponentModel.DataAnnotations;

namespace BS.Data.Entities
{
    public class Role
    {
        [Key]
        public required Guid RoleId { get; set; }

        [StringLength(20)]
        public required string RoleName { get; set; }

        [StringLength(int.MaxValue)]
        public string? RoleDescription { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
