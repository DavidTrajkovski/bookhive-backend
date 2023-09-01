using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHiveDB.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addingPdfUrlColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfUrl",
                table: "Book",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfUrl",
                table: "Book");
        }
    }
}
