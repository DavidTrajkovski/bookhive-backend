using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookHiveDB.Repository.Migrations
{
    public partial class update_models_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_BookClub_BookClubId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Topic_TopicId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_BookClub_BookClubId",
                table: "Topic");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookClubId",
                table: "Topic",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TopicId",
                table: "Post",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BookClubId",
                table: "Invitation",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_BookClub_BookClubId",
                table: "Invitation",
                column: "BookClubId",
                principalTable: "BookClub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Topic_TopicId",
                table: "Post",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_BookClub_BookClubId",
                table: "Topic",
                column: "BookClubId",
                principalTable: "BookClub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_BookClub_BookClubId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Topic_TopicId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_BookClub_BookClubId",
                table: "Topic");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookClubId",
                table: "Topic",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "TopicId",
                table: "Post",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "BookClubId",
                table: "Invitation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_BookClub_BookClubId",
                table: "Invitation",
                column: "BookClubId",
                principalTable: "BookClub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Topic_TopicId",
                table: "Post",
                column: "TopicId",
                principalTable: "Topic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_BookClub_BookClubId",
                table: "Topic",
                column: "BookClubId",
                principalTable: "BookClub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
