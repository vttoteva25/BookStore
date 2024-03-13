using BS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BS.Data.Contexts
{
    public class BookStoreDbContext : IdentityDbContext<Customer>
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
        /// Gets or sets authors dbset collection.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreDbContext"/> class.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public BookStoreDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Book and Order
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Orders)
                .WithMany(o => o.Books)
                .UsingEntity<BookOrder>(
                    j => j
                        .HasOne(bo => bo.Order)
                        .WithMany()
                        .HasForeignKey(bo => bo.OrderId),
                    j => j
                        .HasOne(bo => bo.Book)
                        .WithMany()
                        .HasForeignKey(bo => bo.BookId)
                );

            modelBuilder.Entity<BookOrder>()
                .HasKey(bo => new { bo.BookId, bo.OrderId });

            List<IdentityRole> identityRoles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };         

            modelBuilder.Entity<IdentityRole>()
                .HasData(identityRoles);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
        }

    }
}
