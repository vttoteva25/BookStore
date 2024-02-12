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

        [Range(0.00, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(20)]
        public string? Language { get; set; }

        public int QuantityAvailable { get; set; } = 0;

        public bool Available { get; set; } = false;

        [StringLength(int.MaxValue)]
        public string? Description { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
}
