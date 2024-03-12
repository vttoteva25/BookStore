using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BS.Data.Entities
{
    public class Book
    {
        [Key]
        public required Guid BookId { get; set; }

        [StringLength(50)]
        public required string Title { get; set; }

        [ForeignKey("Author Id")]
        public required Guid AuthorId { get; set; }

        [StringLength(50)]
        public string? Genre {  get; set; }

        [Range(0.00, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(20)]
        public string? ISBN { get; set; }

        [StringLength(20)]
        public string? Language { get; set; }

        public int QuantityAvailable { get; set; } = 0;

        public bool Available { get; set; } = false;

        [StringLength(int.MaxValue)]
        public string? Description { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Author Author { get; set; }


    }
}
