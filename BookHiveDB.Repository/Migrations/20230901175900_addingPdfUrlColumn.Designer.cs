﻿// <auto-generated />
using System;
using BookHiveDB.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookHiveDB.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230901175900_addingPdfUrlColumn")]
    partial class addingPdfUrlColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<Guid>("AuthoredBooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorsId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthoredBooksId", "AuthorsId");

                    b.HasIndex("AuthorsId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookBookShop", b =>
                {
                    b.Property<Guid>("BookShopsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.HasKey("BookShopsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("BookBookShop");
                });

            modelBuilder.Entity("BookHiveDB.Domain.DomainModels.UserBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("lastPageRead")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBook");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Identity.BookHiveApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Biography")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CoverImageUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int[]>("Genres")
                        .HasColumnType("integer[]");

                    b.Property<bool>("IsValid")
                        .HasColumnType("boolean");

                    b.Property<string>("Isbn")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PdfUrl")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("TotalPages")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.BookClub", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BookHiveApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookHiveApplicationUserId");

                    b.ToTable("BookClub");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.BookShop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("bookshopEmail")
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.Property<double>("grade")
                        .HasColumnType("double precision");

                    b.Property<double>("latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<int>("numGraders")
                        .HasColumnType("integer");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("websiteLink")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BookShop");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookClubId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsRequest")
                        .HasColumnType("boolean");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("UserReceiverId")
                        .HasColumnType("text");

                    b.Property<string>("UserSenderId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookClubId");

                    b.HasIndex("UserReceiverId");

                    b.HasIndex("UserSenderId");

                    b.ToTable("Invitation");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BookHiveApplicationUserId")
                        .HasColumnType("text");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uuid");

                    b.Property<string>("content")
                        .HasColumnType("text");

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookHiveApplicationUserId");

                    b.HasIndex("TopicId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("OwnerId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookClubId")
                        .HasColumnType("uuid");

                    b.Property<string>("BookHiveApplicationUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookClubId");

                    b.HasIndex("BookHiveApplicationUserId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Relations.BookInOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("OrderId");

                    b.ToTable("BookInOrder");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Relations.BookInShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("BookInShoppingCart");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Relations.BookInWishList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookInWishList");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Relations.UserInBookClub", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookClubId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookClubId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInBookClub");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("AuthoredBooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookBookShop", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Models.BookShop", null)
                        .WithMany()
                        .HasForeignKey("BookShopsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookHiveDB.Domain.DomainModels.UserBook", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Models.Book", "Book")
                        .WithMany("UserBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "BookHiveApplicationUser")
                        .WithMany("userBooks")
                        .HasForeignKey("UserId");

                    b.Navigation("Book");

                    b.Navigation("BookHiveApplicationUser");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.BookClub", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "BookHiveApplicationUser")
                        .WithMany("BookClubsOwned")
                        .HasForeignKey("BookHiveApplicationUserId");

                    b.Navigation("BookHiveApplicationUser");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Invitation", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Models.BookClub", "BookClub")
                        .WithMany("Invitations")
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "UserReceiver")
                        .WithMany("InvitationsReceived")
                        .HasForeignKey("UserReceiverId");

                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "UserSender")
                        .WithMany("InvitationsSent")
                        .HasForeignKey("UserSenderId");

                    b.Navigation("BookClub");

                    b.Navigation("UserReceiver");

                    b.Navigation("UserSender");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Order", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Post", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "BookHiveApplicationUser")
                        .WithMany("Posts")
                        .HasForeignKey("BookHiveApplicationUserId");

                    b.HasOne("BookHiveDB.Domain.Models.Topic", "Topic")
                        .WithMany("PostsBelonging")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookHiveApplicationUser");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.ShoppingCart", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "Owner")
                        .WithOne("UserCart")
                        .HasForeignKey("BookHiveDB.Domain.Models.ShoppingCart", "OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Topic", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Models.BookClub", "BookClub")
                        .WithMany("Topics")
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "BookHiveApplicationUser")
                        .WithMany("TopicsCreated")
                        .HasForeignKey("BookHiveApplicationUserId");

                    b.Navigation("BookClub");

                    b.Navigation("BookHiveApplicationUser");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Relations.BookInOrder", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Models.Book", "Book")
                        .WithMany("BooksInOrders")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Models.Order", "Order")
                        .WithMany("BooksInOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Relations.BookInShoppingCart", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Models.Book", "Book")
                        .WithMany("BookInShoppingCarts")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("BookInShoppingCarts")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Relations.BookInWishList", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Models.Book", "Book")
                        .WithMany("BookInWishLists")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "User")
                        .WithMany("BookInWishLists")
                        .HasForeignKey("UserId");

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Relations.UserInBookClub", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Models.BookClub", "BookClub")
                        .WithMany("UserInBookClubs")
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", "BookHiveApplicationUser")
                        .WithMany("UserInBookClubs")
                        .HasForeignKey("UserId");

                    b.Navigation("BookClub");

                    b.Navigation("BookHiveApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BookHiveDB.Domain.Identity.BookHiveApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookHiveDB.Domain.Identity.BookHiveApplicationUser", b =>
                {
                    b.Navigation("BookClubsOwned");

                    b.Navigation("BookInWishLists");

                    b.Navigation("InvitationsReceived");

                    b.Navigation("InvitationsSent");

                    b.Navigation("Posts");

                    b.Navigation("TopicsCreated");

                    b.Navigation("UserCart");

                    b.Navigation("UserInBookClubs");

                    b.Navigation("userBooks");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Book", b =>
                {
                    b.Navigation("BookInShoppingCarts");

                    b.Navigation("BookInWishLists");

                    b.Navigation("BooksInOrders");

                    b.Navigation("UserBooks");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.BookClub", b =>
                {
                    b.Navigation("Invitations");

                    b.Navigation("Topics");

                    b.Navigation("UserInBookClubs");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Order", b =>
                {
                    b.Navigation("BooksInOrders");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.ShoppingCart", b =>
                {
                    b.Navigation("BookInShoppingCarts");
                });

            modelBuilder.Entity("BookHiveDB.Domain.Models.Topic", b =>
                {
                    b.Navigation("PostsBelonging");
                });
#pragma warning restore 612, 618
        }
    }
}
