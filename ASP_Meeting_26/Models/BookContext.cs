using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASP_Meeting_26.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", Price = 200 },
                new Book { Id = 2, Title = "The Way Station", Author = "Clifford Simak", Price = 250}
                );
        }
    }
}
