using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookHiveDB.Repository.Migrations
{
    public partial class book_class_finished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Authors_AuthorId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookClubs_AspNetUsers_BookHiveApplicationUserId",
                table: "BookClubs");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Books_BookId",
                table: "BookGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenres_Genres_GenreId",
                table: "BookGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInBookShop_Books_BookId",
                table: "BookInBookShop");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInBookShop_BookShops_BookShopId",
                table: "BookInBookShop");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInBookShop_ShoppingCart_ShoppingCartId",
                table: "BookInBookShop");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInOrder_Books_BookId",
                table: "BookInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCart_Books_BookId",
                table: "BookInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInWishList_Books_BookId",
                table: "BookInWishList");

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

            migrationBuilder.DropForeignKey(
                name: "FK_UserBooks_Books_BookId",
                table: "UserBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBooks_AspNetUsers_UserId",
                table: "UserBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInBookClub_BookClubs_BookClubId",
                table: "UserInBookClub");

            migrationBuilder.DropIndex(
                name: "IX_BookInBookShop_ShoppingCartId",
                table: "BookInBookShop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookShops",
                table: "BookShops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGenres",
                table: "BookGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookClubs",
                table: "BookClubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBooks",
                table: "AuthorBooks");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "BookInBookShop");

            migrationBuilder.RenameTable(
                name: "UserBooks",
                newName: "UserBook");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topic");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "Invitations",
                newName: "Invitation");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "BookShops",
                newName: "BookShop");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "BookGenres",
                newName: "BookGenre");

            migrationBuilder.RenameTable(
                name: "BookClubs",
                newName: "BookClub");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameTable(
                name: "AuthorBooks",
                newName: "AuthorBook");

            migrationBuilder.RenameIndex(
                name: "IX_UserBooks_BookId",
                table: "UserBook",
                newName: "IX_UserBook_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_BookHiveApplicationUserId",
                table: "Topic",
                newName: "IX_Topic_BookHiveApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Topics_BookClubId",
                table: "Topic",
                newName: "IX_Topic_BookClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_TopicId",
                table: "Post",
                newName: "IX_Post_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_BookHiveApplicationUserId",
                table: "Post",
                newName: "IX_Post_BookHiveApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invitations_UserSenderId",
                table: "Invitation",
                newName: "IX_Invitation_UserSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Invitations_UserReceiverId",
                table: "Invitation",
                newName: "IX_Invitation_UserReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Invitations_BookClubId",
                table: "Invitation",
                newName: "IX_Invitation_BookClubId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenres_GenreId",
                table: "BookGenre",
                newName: "IX_BookGenre_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenres_BookId",
                table: "BookGenre",
                newName: "IX_BookGenre_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookClubs_BookHiveApplicationUserId",
                table: "BookClub",
                newName: "IX_BookClub_BookHiveApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_BookId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBooks_AuthorId",
                table: "AuthorBook",
                newName: "IX_AuthorBook_AuthorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookShopId",
                table: "BookInBookShop",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook",
                columns: new[] { "UserId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                table: "Topic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invitation",
                table: "Invitation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookShop",
                table: "BookShop",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGenre",
                table: "BookGenre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookClub",
                table: "BookClub",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookClub_AspNetUsers_BookHiveApplicationUserId",
                table: "BookClub",
                column: "BookHiveApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Book_BookId",
                table: "BookGenre",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Genre_GenreId",
                table: "BookGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInBookShop_Book_BookId",
                table: "BookInBookShop",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInBookShop_BookShop_BookShopId",
                table: "BookInBookShop",
                column: "BookShopId",
                principalTable: "BookShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInOrder_Book_BookId",
                table: "BookInOrder",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInShoppingCart_Book_BookId",
                table: "BookInShoppingCart",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInWishList_Book_BookId",
                table: "BookInWishList",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_BookClub_BookClubId",
                table: "Invitation",
                column: "BookClubId",
                principalTable: "BookClub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_AspNetUsers_UserReceiverId",
                table: "Invitation",
                column: "UserReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invitation_AspNetUsers_UserSenderId",
                table: "Invitation",
                column: "UserSenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_BookHiveApplicationUserId",
                table: "Post",
                column: "BookHiveApplicationUserId",
                principalTable: "AspNetUsers",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_AspNetUsers_BookHiveApplicationUserId",
                table: "Topic",
                column: "BookHiveApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Book_BookId",
                table: "UserBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_AspNetUsers_UserId",
                table: "UserBook",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInBookClub_BookClub_BookClubId",
                table: "UserInBookClub",
                column: "BookClubId",
                principalTable: "BookClub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Author_AuthorId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook");

            migrationBuilder.DropForeignKey(
                name: "FK_BookClub_AspNetUsers_BookHiveApplicationUserId",
                table: "BookClub");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Book_BookId",
                table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genre_GenreId",
                table: "BookGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInBookShop_Book_BookId",
                table: "BookInBookShop");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInBookShop_BookShop_BookShopId",
                table: "BookInBookShop");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInOrder_Book_BookId",
                table: "BookInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInShoppingCart_Book_BookId",
                table: "BookInShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInWishList_Book_BookId",
                table: "BookInWishList");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_BookClub_BookClubId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_AspNetUsers_UserReceiverId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Invitation_AspNetUsers_UserSenderId",
                table: "Invitation");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_BookHiveApplicationUserId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Topic_TopicId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_BookClub_BookClubId",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_AspNetUsers_BookHiveApplicationUserId",
                table: "Topic");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Book_BookId",
                table: "UserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_AspNetUsers_UserId",
                table: "UserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInBookClub_BookClub_BookClubId",
                table: "UserInBookClub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBook",
                table: "UserBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invitation",
                table: "Invitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookShop",
                table: "BookShop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookGenre",
                table: "BookGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookClub",
                table: "BookClub");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "UserBook",
                newName: "UserBooks");

            migrationBuilder.RenameTable(
                name: "Topic",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Invitation",
                newName: "Invitations");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "BookShop",
                newName: "BookShops");

            migrationBuilder.RenameTable(
                name: "BookGenre",
                newName: "BookGenres");

            migrationBuilder.RenameTable(
                name: "BookClub",
                newName: "BookClubs");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "AuthorBook",
                newName: "AuthorBooks");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_UserBook_BookId",
                table: "UserBooks",
                newName: "IX_UserBooks_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Topic_BookHiveApplicationUserId",
                table: "Topics",
                newName: "IX_Topics_BookHiveApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Topic_BookClubId",
                table: "Topics",
                newName: "IX_Topics_BookClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_TopicId",
                table: "Posts",
                newName: "IX_Posts_TopicId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_BookHiveApplicationUserId",
                table: "Posts",
                newName: "IX_Posts_BookHiveApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invitation_UserSenderId",
                table: "Invitations",
                newName: "IX_Invitations_UserSenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Invitation_UserReceiverId",
                table: "Invitations",
                newName: "IX_Invitations_UserReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Invitation_BookClubId",
                table: "Invitations",
                newName: "IX_Invitations_BookClubId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenre_GenreId",
                table: "BookGenres",
                newName: "IX_BookGenres_GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenre_BookId",
                table: "BookGenres",
                newName: "IX_BookGenres_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookClub_BookHiveApplicationUserId",
                table: "BookClubs",
                newName: "IX_BookClubs_BookHiveApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBook_AuthorId",
                table: "AuthorBooks",
                newName: "IX_AuthorBooks_AuthorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "BookShopId",
                table: "BookInBookShop",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartId",
                table: "BookInBookShop",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBooks",
                table: "UserBooks",
                columns: new[] { "UserId", "BookId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                table: "Topics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invitations",
                table: "Invitations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookShops",
                table: "BookShops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookGenres",
                table: "BookGenres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookClubs",
                table: "BookClubs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBooks",
                table: "AuthorBooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookInBookShop_ShoppingCartId",
                table: "BookInBookShop",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Authors_AuthorId",
                table: "AuthorBooks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBooks_Books_BookId",
                table: "AuthorBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookClubs_AspNetUsers_BookHiveApplicationUserId",
                table: "BookClubs",
                column: "BookHiveApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Books_BookId",
                table: "BookGenres",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenres_Genres_GenreId",
                table: "BookGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInBookShop_Books_BookId",
                table: "BookInBookShop",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInBookShop_BookShops_BookShopId",
                table: "BookInBookShop",
                column: "BookShopId",
                principalTable: "BookShops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInBookShop_ShoppingCart_ShoppingCartId",
                table: "BookInBookShop",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInOrder_Books_BookId",
                table: "BookInOrder",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInShoppingCart_Books_BookId",
                table: "BookInShoppingCart",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInWishList_Books_BookId",
                table: "BookInWishList",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserBooks_Books_BookId",
                table: "UserBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBooks_AspNetUsers_UserId",
                table: "UserBooks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInBookClub_BookClubs_BookClubId",
                table: "UserInBookClub",
                column: "BookClubId",
                principalTable: "BookClubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
