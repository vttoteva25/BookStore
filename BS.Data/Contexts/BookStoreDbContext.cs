﻿using BS.Data.Entities;
using BS.Data.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BS.Data.Contexts
{
    public class BookStoreDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets book dbset collection.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets users dbset collection.
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

            modelBuilder.Entity<User>().HasData(
              new User
              {
                  UserId = Guid.Parse("478a65ac-3492-4dd1-91dd-730d6ad9fbbc"),
                  FirstName = "Viktoriya",
                  LastName = "Toteva",                 
                  PhoneNumber = "0885904536",
                  Username = "vttoteva",
                  Email = "viktoriya.toteva@abv.bg",
                  Address = "Kazanlak",
                  Password = Hasher.Hash("12345"),
                  RegistrationDate = DateTime.Now
              }
            );

            modelBuilder.Entity<User>().HasData(
              new User
              {
                  UserId = Guid.Parse("b2235601-6b68-4b56-a4c1-c4055d479931"),
                  FirstName = "Iva",
                  LastName = "Tananska",
                  PhoneNumber = "0885904536",
                  Username = "itananska",
                  Email = "iva.tananska@abv.bg",
                  Address = "Plovdiv",
                  Password = Hasher.Hash("12345"),
                  RegistrationDate = DateTime.Now
              }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    RoleId = Guid.Parse("111e16d2-2a45-4977-a963-0fd740fbacb8"),
                    UserId = Guid.Parse("478a65ac-3492-4dd1-91dd-730d6ad9fbbc")
                }) ;

            modelBuilder.Entity<UserRole>().HasData(
              new UserRole
              {
                  RoleId = Guid.Parse("e89e16d2-2a45-4977-a963-0fd740fbacb8"),
                  UserId = Guid.Parse("478a65ac-3492-4dd1-91dd-730d6ad9fbbc")
              });

            modelBuilder.Entity<UserRole>().HasData(
              new UserRole
              {
                  RoleId = Guid.Parse("111e16d2-2a45-4977-a963-0fd740fbacb8"),
                  UserId = Guid.Parse("b2235601-6b68-4b56-a4c1-c4055d479931")
              });

            modelBuilder.Entity<UserRole>().HasData(
              new UserRole
              {
                  RoleId = Guid.Parse("e89e16d2-2a45-4977-a963-0fd740fbacb8"),
                  UserId = Guid.Parse("b2235601-6b68-4b56-a4c1-c4055d479931")
              });
        }

    }
}
