namespace BS.ApplicationServices.ViewModels
{
    public class AuthorVM
    {
        public Guid AuthorId { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Email { get; set; }

        public DateTime CareerStartingDate { get; set; }

        public int WrittenBooksCount { get; set; }

        public bool IsActiveNow { get; set; }

        public string? Description { get; set; }
    }
}
