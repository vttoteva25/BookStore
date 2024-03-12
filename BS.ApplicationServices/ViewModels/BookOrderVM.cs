using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.ApplicationServices.ViewModels
{
    public class BookOrderVM
    {
        public required Guid BookId { get; set; }

        public required Guid OrderId { get; set; }
    }
}
