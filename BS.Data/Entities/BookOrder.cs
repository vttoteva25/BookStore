using System.ComponentModel.DataAnnotations.Schema;

namespace BS.Data.Entities
{
    public class BookOrder
    {
        [ForeignKey("Book Id")]
        public required Guid BookId { get; set; }

        [ForeignKey("Order Id")]
        public required Guid OrderId { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}
