using System.ComponentModel.DataAnnotations;

namespace BS.Data.Entities
{
    public class Book
    {
        [Key]
        public required Guid BookId { get; set; }

        [StringLength(50)]
        public required string Title { get; set; }

        [StringLength(50)]
        public string? Author { get; set; }

        [StringLength(50)]
        public string? Genre {  get; set; }

        public decimal Price { get; set; }

        [StringLength(20)]
        public string? Language { get; set; }

        public int QuantityAvailable { get; set; }

        public bool Available { get; set; }

        [StringLength(int.MaxValue)]
        public string? Description { get; set; }
    }
}
