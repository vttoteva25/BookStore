namespace BS.ApplicationServices.ViewModels
{
    public class RoleVM
    {
        public Guid RoleId { get; set; }

        public required string RoleName { get; set; }

        public string? RoleDescription { get; set; }
    }
}
