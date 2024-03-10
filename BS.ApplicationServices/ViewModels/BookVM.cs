using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.ViewModels
{
    public class BookVM
    {
        public required Guid BookId { get; set; }

        public required string Title { get; set; }

        public required Guid AuthorId { get; set; }

        public string? Genre { get; set; }

        public decimal Price { get; set; }

        public string? ISBN { get; set; }

        public string? Language { get; set; }

        public int QuantityAvailable { get; set; }

        public bool Available { get; set; } = false;

        public string? Description { get; set; }

        public ICollection<OrderVM> Orders { get; set; }

        public AuthorVM Author { get; set; }
    }
}
