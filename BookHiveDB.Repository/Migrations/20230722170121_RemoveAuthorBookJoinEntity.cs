using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHiveDB.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthorBookJoinEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Author_AuthorId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook");

            migrationBuilder.DropIndex(
                name: "IX_AuthorBook_AuthorId",
                table: "AuthorBook");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AuthorBook");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "AuthorBook",
                newName: "AuthorsId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "AuthorBook",
                newName: "AuthoredBooksId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_AuthorsId");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "Author",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Author",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "biography",
                table: "Author",
                newName: "Biography");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Author",
                newName: "Age");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook",
                columns: new[] { "AuthoredBooksId", "AuthorsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Author_AuthorsId",
                table: "AuthorBook",
                column: "AuthorsId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_AuthoredBooksId",
                table: "AuthorBook",
                column: "AuthoredBooksId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Author_AuthorsId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_AuthoredBooksId",
                table: "AuthorBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook");

            migrationBuilder.RenameColumn(
                name: "AuthorsId",
                table: "AuthorBook",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "AuthoredBooksId",
                table: "AuthorBook",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_AuthorsId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BookId");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Author",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Author",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Author",
                newName: "biography");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Author",
                newName: "age");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AuthorBook",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_AuthorId",
                table: "AuthorBook",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Author_AuthorId",
                table: "AuthorBook",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
