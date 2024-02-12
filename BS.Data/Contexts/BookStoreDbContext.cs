using BS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BS.Data.Contexts
{
    public class BookStoreDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets book dbset collection.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets customer dbset collection.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets order dbset collection.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets book-order dbset collection.
        /// </summary>
        public DbSet<BookOrder> BooksOrders { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesDbContext"/> class.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
    
    }
}
