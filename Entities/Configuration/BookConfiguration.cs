using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;


namespace Entities.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
                (
                new Book
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Title = "Война и мир",
                    Year = 2005,
                    //AuthorId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                    //Authors = new List<Author>() { new Author { Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") } }
                },
                new Book
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Title = "Идиот_1",
                    Year = 1800,
                    //Authors = new List<Author>() { new Author { Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") } }
                    //AuthorId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")

                },
                new Book
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Title = "Идиот_2",
                    Year = 1800,
                    //Authors = new List<Author> { new Author { Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") } }
                    //AuthorId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                }
                );
        }
    }
}
