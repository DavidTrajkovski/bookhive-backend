using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHiveDB.Repository.Migrations
{
    /// <inheritdoc />
    public partial class RenameInvitationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "message",
                table: "Invitation",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "isRequest",
                table: "Invitation",
                newName: "IsRequest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Invitation",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "IsRequest",
                table: "Invitation",
                newName: "isRequest");
        }
    }
}
