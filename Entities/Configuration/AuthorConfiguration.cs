using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData
                (new Author
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Лев Толстой",
                    //Books = new List<Book> { new Book { Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a") } }
                },
                new Author
                {
                 
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Федор Достоевский",
                    //Books = new List<Book> { new Book { Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a") }, new Book { Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811") } }
                }
                );
        }
    }
}
