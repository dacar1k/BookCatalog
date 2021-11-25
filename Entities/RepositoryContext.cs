using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Entities.Configuration;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                     
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.Entity<AuthorBook>().HasOne(b => b.Book).WithMany(ab => ab.AuthorBook).HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<AuthorBook>().HasOne(a => a.Author).WithMany(ab => ab.AuthorBook).HasForeignKey(ai => ai.AuthorId);
            //modelBuilder.ApplyConfiguration(new AuthorBookConfiguration());

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        
        public DbSet<AuthorBook> AuthorBook { get; set; } //Fix v0.1

    }
}
