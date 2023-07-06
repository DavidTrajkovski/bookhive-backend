using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookHiveDB.Repository.Migrations
{
    public partial class model_price_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookClubId",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookHiveApplicationUserId",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookHiveApplicationUserId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookClubId",
                table: "Invitations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserReceiverId",
                table: "Invitations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSenderId",
                table: "Invitations",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Books",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "BookHiveApplicationUserId",
                table: "BookClubs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookInBookShop",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    ShoppingCartId = table.Column<Guid>(nullable: false),
                    BookShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInBookShop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookInBookShop_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookInBookShop_BookShops_BookShopId",
                        column: x => x.BookShopId,
                        principalTable: "BookShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookInBookShop_ShoppingCart_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookInWishList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    BookId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInWishList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookInWishList_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookInWishList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInBookClub",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BookClubId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInBookClub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInBookClub_BookClubs_BookClubId",
                        column: x => x.BookClubId,
                        principalTable: "BookClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInBookClub_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_BookClubId",
                table: "Topics",
                column: "BookClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_BookHiveApplicationUserId",
                table: "Topics",
                column: "BookHiveApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BookHiveApplicationUserId",
                table: "Posts",
                column: "BookHiveApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_BookClubId",
                table: "Invitations",
                column: "BookClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_UserReceiverId",
                table: "Invitations",
                column: "UserReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_UserSenderId",
                table: "Invitations",
                column: "UserSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_BookClubs_BookHiveApplicationUserId",
                table: "BookClubs",
                column: "BookHiveApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInBookShop_BookId",
                table: "BookInBookShop",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInBookShop_BookShopId",
                table: "BookInBookShop",
                column: "BookShopId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInBookShop_ShoppingCartId",
                table: "BookInBookShop",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInWishList_BookId",
                table: "BookInWishList",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInWishList_UserId",
                table: "BookInWishList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInBookClub_BookClubId",
                table: "UserInBookClub",
                column: "BookClubId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInBookClub_UserId",
                table: "UserInBookClub",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookClubs_AspNetUsers_BookHiveApplicationUserId",
                table: "BookClubs",
                column: "BookHiveApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_BookClubs_BookClubId",
                table: "Invitations",
                column: "BookClubId",
                principalTable: "BookClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_AspNetUsers_UserReceiverId",
                table: "Invitations",
                column: "UserReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitations_AspNetUsers_UserSenderId",
                table: "Invitations",
                column: "UserSenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_BookHiveApplicationUserId",
                table: "Posts",
                column: "BookHiveApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_BookClubs_BookClubId",
                table: "Topics",
                column: "BookClubId",
                principalTable: "BookClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_BookHiveApplicationUserId",
                table: "Topics",
                column: "BookHiveApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookClubs_AspNetUsers_BookHiveApplicationUserId",
                table: "BookClubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_BookClubs_BookClubId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_AspNetUsers_UserReceiverId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitations_AspNetUsers_UserSenderId",
                table: "Invitations");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_BookHiveApplicationUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Topics_TopicId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_BookClubs_BookClubId",
                table: "Topics");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_BookHiveApplicationUserId",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "BookInBookShop");

            migrationBuilder.DropTable(
                name: "BookInWishList");

            migrationBuilder.DropTable(
                name: "UserInBookClub");

            migrationBuilder.DropIndex(
                name: "IX_Topics_BookClubId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_BookHiveApplicationUserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Posts_BookHiveApplicationUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TopicId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_BookClubId",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_UserReceiverId",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_Invitations_UserSenderId",
                table: "Invitations");

            migrationBuilder.DropIndex(
                name: "IX_BookClubs_BookHiveApplicationUserId",
                table: "BookClubs");

            migrationBuilder.DropColumn(
                name: "BookClubId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "BookHiveApplicationUserId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "BookHiveApplicationUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "BookClubId",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "UserReceiverId",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "UserSenderId",
                table: "Invitations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookHiveApplicationUserId",
                table: "BookClubs");
        }
    }
}
