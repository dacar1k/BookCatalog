using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    internal class AuthorBookConfiguration: IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasData(
                new AuthorBook
                {
                    Id = new Guid ("de760c97-998b-4f88-b9fb-ff80ee366d56"),
                    AuthorId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    BookId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new AuthorBook
                {
                    Id = new Guid("f3e9741e-001e-47b1-aed6-213ef77c65dd"),
                    AuthorId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    BookId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")
                },
                new AuthorBook
                {
                    Id = new Guid("a7f6ecee-0586-4f42-a1f6-09c7bea59cfb"),
                    AuthorId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    BookId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")                   
                }
                ) ;
        }
    }
}
