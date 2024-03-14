using BS.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<User> Users { get; set; }

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

        // <summary>
        /// Gets or sets roles dbset collection.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        // <summary>
        /// Gets or sets users and roles dbset collection.
        /// </summary>
        public DbSet<UserRole> UsersRoles { get; set; }

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

            modelBuilder.Entity<User>()
                 .HasMany(b => b.Roles)
                 .WithMany(o => o.Users)
                 .UsingEntity<UserRole>(
                     j => j
                         .HasOne(bo => bo.Role)
                         .WithMany()
                         .HasForeignKey(bo => bo.RoleId),
                     j => j
                         .HasOne(bo => bo.User)
                         .WithMany()
                         .HasForeignKey(bo => bo.UserId)
                 );

            modelBuilder.Entity<UserRole>()
                .HasKey(bo => new { bo.UserId, bo.RoleId });


            modelBuilder.Entity<Role>().HasData(
               new Role
               {
                   RoleId = Guid.Parse("111e16d2-2a45-4977-a963-0fd740fbacb8"),
                   RoleName = "Admin"
               });

            modelBuilder.Entity<Role>().HasData(
              new Role
              {
                  RoleId = Guid.Parse("e89e16d2-2a45-4977-a963-0fd740fbacb8"),
                  RoleName = "User"
              });
                   
        }

    }
}
