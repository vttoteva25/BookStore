using System.ComponentModel.DataAnnotations;

namespace BS.ApplicationServices.ViewModels
{
    public class BookOrderVM
    {
        public required Guid BookId { get; set; }

        public required Guid OrderId { get; set; }
    }
}
