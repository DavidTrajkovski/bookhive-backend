using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHiveDB.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveGenresTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.RenameColumn(
                name: "totalPages",
                table: "Book",
                newName: "TotalPages");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Book",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isbn",
                table: "Book",
                newName: "Isbn");

            migrationBuilder.RenameColumn(
                name: "isValid",
                table: "Book",
                newName: "IsValid");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Book",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "datePublished",
                table: "Book",
                newName: "DatePublished");

            migrationBuilder.RenameColumn(
                name: "coverImageUrl",
                table: "Book",
                newName: "CoverImageUrl");

            migrationBuilder.AddColumn<int[]>(
                name: "Genres",
                table: "Book",
                type: "integer[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genres",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "TotalPages",
                table: "Book",
                newName: "totalPages");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Book",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Isbn",
                table: "Book",
                newName: "isbn");

            migrationBuilder.RenameColumn(
                name: "IsValid",
                table: "Book",
                newName: "isValid");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Book",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "DatePublished",
                table: "Book",
                newName: "datePublished");

            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "Book",
                newName: "coverImageUrl");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookGenre_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_BookId",
                table: "BookGenre",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenreId",
                table: "BookGenre",
                column: "GenreId");
        }
    }
}
