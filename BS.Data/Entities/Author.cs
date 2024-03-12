using System.ComponentModel.DataAnnotations;

namespace BS.Data.Entities
{
    public class Author
    {
        [Key]
        public required Guid AuthorId { get; set; }

        [StringLength(20)]
        public required string FirstName { get; set; }

        [StringLength(20)]
        public required string LastName { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        public DateTime CareerStartingDate { get; set; }

        public int WrittenBooksCount { get; set; } = 0;

        public bool IsActiveNow { get; set; }

        [StringLength(int.MaxValue)]
        public string? Description { get; set; }
    }
}
