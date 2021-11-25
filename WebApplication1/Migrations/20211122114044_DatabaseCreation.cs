using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCatalog.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Федор Достоевский" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Лев Толстой" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Title", "Year" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Идиот_2", 1800 },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Война и мир", 2005 },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Идиот_1", 1800 }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "Id", "AuthorId", "BookId" },
                values: new object[] { new Guid("a7f6ecee-0586-4f42-a1f6-09c7bea59cfb"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "Id", "AuthorId", "BookId" },
                values: new object[] { new Guid("de760c97-998b-4f88-b9fb-ff80ee366d56"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811") });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "Id", "AuthorId", "BookId" },
                values: new object[] { new Guid("f3e9741e-001e-47b1-aed6-213ef77c65dd"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a") });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_AuthorId",
                table: "AuthorBook",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBook",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
