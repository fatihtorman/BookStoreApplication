using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Text;

namespace Repository
{
    public class BookStoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=localhost; port=3306; database=order; user=root; password=33333; Persist Security Info=False; Connect Timeout=300";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Isbn> Isbns { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }
    }
}
