using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHiveDB.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBooksInBookStoreJoinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInBookShop");

            migrationBuilder.CreateTable(
                name: "BookBookShop",
                columns: table => new
                {
                    BookShopsId = table.Column<Guid>(type: "uuid", nullable: false),
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookShop", x => new { x.BookShopsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_BookBookShop_BookShop_BookShopsId",
                        column: x => x.BookShopsId,
                        principalTable: "BookShop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookShop_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookShop_BooksId",
                table: "BookBookShop",
                column: "BooksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookShop");

            migrationBuilder.CreateTable(
                name: "BookInBookShop",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookShopId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInBookShop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookInBookShop_BookShop_BookShopId",
                        column: x => x.BookShopId,
                        principalTable: "BookShop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookInBookShop_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookInBookShop_BookId",
                table: "BookInBookShop",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInBookShop_BookShopId",
                table: "BookInBookShop",
                column: "BookShopId");
        }
    }
}
