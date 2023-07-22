using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookHiveDB.Repository
{
    public class ApplicationDbContext : IdentityDbContext<BookHiveApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Author>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Book>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<AuthorBook>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<BookClub>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<BookShop>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Invitation>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Post>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Topic>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Genre>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<BookGenre>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<BookInWishList>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<UserBook>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<UserBook>()
                .HasOne(z => z.BookHiveApplicationUser)
                .WithMany(z => z.userBooks)
                .HasForeignKey(z => z.UserId);

            builder.Entity<UserBook>()
                .HasOne(z => z.Book)
                .WithMany(z => z.userBooks)
                .HasForeignKey(z => z.BookId);


            builder.Entity<AuthorBook>()
                .HasOne(z => z.Author)
                .WithMany(z => z.authorBooks)
                .HasForeignKey(z => z.AuthorId);

            builder.Entity<AuthorBook>()
                .HasOne(z => z.Book)
                .WithMany(z => z.authorBooks)
                .HasForeignKey(z => z.BookId);

            builder.Entity<BookGenre>()
                .HasOne(z => z.Book)
                .WithMany(z => z.BookGenres)
                .HasForeignKey(z => z.BookId);

            builder.Entity<BookGenre>()
                .HasOne(z => z.Genre)
                .WithMany(z => z.BookGenres)
                .HasForeignKey(z => z.GenreId);

            builder.Entity<BookInWishList>()
                .HasOne(z => z.User)
                .WithMany(z => z.BookInWishLists)
                .HasForeignKey(z => z.UserId);

            builder.Entity<BookInWishList>()
                .HasOne(z => z.Book)
                .WithMany(z => z.BookInWishLists)
                .HasForeignKey(z => z.BookId);

            builder.Entity<UserInBookClub>()
                .HasOne(z => z.BookHiveApplicationUser)
                .WithMany(z => z.UserInBookClubs)
                .HasForeignKey(z => z.UserId);

            builder.Entity<UserInBookClub>()
                .HasOne(z => z.BookClub)
                .WithMany(z => z.UserInBookClubs)
                .HasForeignKey(z => z.BookClubId);

            builder.Entity<BookClub>()
                .HasOne(z => z.BookHiveApplicationUser)
                .WithMany(z => z.BookClubsOwned)
                .HasForeignKey(z => z.BookHiveApplicationUserId);

            builder.Entity<Topic>()
                .HasOne(z => z.BookHiveApplicationUser)
                .WithMany(z => z.TopicsCreated)
                .HasForeignKey(z => z.BookHiveApplicationUserId);

            builder.Entity<Topic>()
                .HasOne(z => z.BookClub)
                .WithMany(z => z.Topics)
                .HasForeignKey(z => z.BookClubId);

            builder.Entity<Invitation>()
                .HasOne(z => z.BookClub)
                .WithMany(z => z.Invitations)
                .HasForeignKey(z => z.BookClubId);

            builder.Entity<Invitation>()
                .HasOne(z => z.UserSender)
                .WithMany(z => z.InvitationsSent)
                .HasForeignKey(z => z.UserSenderId);

            builder.Entity<Invitation>()
                .HasOne(z => z.UserReceiver)
                .WithMany(z => z.InvitationsReceived)
                .HasForeignKey(z => z.UserReceiverId);

            builder.Entity<BookInOrder>()
                .HasOne(z => z.Book)
                .WithMany(z => z.BooksInOrders)
                .HasForeignKey(z => z.BookId);

            builder.Entity<BookInOrder>()
                .HasOne(z => z.Order)
                .WithMany(z => z.BooksInOrders)
                .HasForeignKey(z => z.OrderId);

            builder.Entity<BookInWishList>()
                .HasOne(z => z.Book)
                .WithMany(z => z.BookInWishLists)
                .HasForeignKey(z => z.BookId);

            builder.Entity<BookInWishList>()
                .HasOne(z => z.User)
                .WithMany(z => z.BookInWishLists)
                .HasForeignKey(z => z.UserId);

            builder.Entity<BookInBookShop>()
                .HasOne(z => z.BookShop)
                .WithMany(z => z.BookInBookShops)
                .HasForeignKey(z => z.BookShopId);

            builder.Entity<BookInBookShop>()
                .HasOne(z => z.Book)
                .WithMany(z => z.BookInBookShops)
                .HasForeignKey(z => z.BookId);

            builder.Entity<BookInShoppingCart>()
                .HasOne(z => z.Book)
                .WithMany(z => z.BookInShoppingCarts)
                .HasForeignKey(z => z.BookId);

            builder.Entity<BookInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.BookInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<Post>()
                .HasOne(z => z.Topic)
                .WithMany(z => z.PostsBelonging)
                .HasForeignKey(z => z.TopicId);

            builder.Entity<Post>()
                .HasOne(z => z.BookHiveApplicationUser)
                .WithMany(z => z.Posts)
                .HasForeignKey(z => z.BookHiveApplicationUserId);

            builder.Entity<ShoppingCart>()
                .HasOne(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);
        }
    }
}
