using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.Dtos.Rest;
using BookHiveDB.Domain.Dtos.REST.Author;
using BookHiveDB.Domain.Dtos.REST.Book;
using BookHiveDB.Domain.Dtos.Rest.BookClub;
using BookHiveDB.Domain.Dtos.Rest.BookShop;
using BookHiveDB.Domain.Dtos.Rest.ShoppingCart;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Domain.Models;
using BookHiveDB.Domain.Relations;
using ShoppingCartMvcDto = BookHiveDB.Domain.Dtos.Mvc.ShoppingCartDto;

namespace BookHiveDB.Web.AutoMapper;

public class BookHiveAutoMapperProfile : Profile
{
    public BookHiveAutoMapperProfile()
    {
        CreateMap<BookHiveApplicationUser, UserDto>();
        
        // Author
        CreateMap<CreateAuthorDto, Author>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, BookAuthorInfoDto>();

        // Book
        CreateMap<CreateBookDto, Book>();
        CreateMap<Book, AuthorBookDto>().ForMember(dest => dest.bookName, opt => opt.MapFrom(src => src.Name));
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(
                    src => src.Genres.Select(g => g.ToString())));
        CreateMap<Book, BookShopBookDto>();

        // BookShop
        CreateMap<CreateBookShopDto, BookShop>();
        CreateMap<BookShop, BookShopDto>();

        // BookClubs
        CreateMap<CreateBookClubDto, BookClub>().ForMember(dest => dest.BookHiveApplicationUserId,
            opt => opt.MapFrom(src => src.OwnerId));
        CreateMap<BookClub, BookClubDto>().ForMember(dest => dest.Owner,
            opt => opt.MapFrom(src =>
                $"{src.BookHiveApplicationUser.FirstName} {src.BookHiveApplicationUser.LastName}"));
        CreateMap<BookHiveApplicationUser, MemberDto>();

        // Topics
        CreateMap<Topic, TopicDto>()
            .ForMember(dest => dest.CreatedBy,
                opt => opt.MapFrom(src =>
                    $"{src.BookHiveApplicationUser.FirstName} {src.BookHiveApplicationUser.LastName}"))
            .ForMember(dest => dest.BookclubId, opt => opt.MapFrom(src => src.BookClubId));
        CreateMap<Post, PostDto>()
            .ForMember(dest => dest.Creator,
                opt => opt.MapFrom(src =>
                    $"{src.BookHiveApplicationUser.FirstName} {src.BookHiveApplicationUser.LastName}"))
            .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.BookHiveApplicationUserId));

        // Invitations
        CreateMap<Invitation, InvitationDto>()
            .ForMember(dest => dest.BookClubName, opt => opt.MapFrom(src => src.BookClub.name))
            .ForMember(dest => dest.SenderEmail, opt => opt.MapFrom(src => src.UserSender.Email));

        // Shopping Cart
        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.BookInShoppingCarts));
        
        // ShoppingCartDto (ShoppingCart)
        CreateMap<ShoppingCartMvcDto, ShoppingCartInfoDto>()
            .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.BookInShoppingCarts));
        
        // ShoppingCartBookDto (BookInShoppingCart)
        CreateMap<BookInShoppingCart, ShoppingCartBookDto>()
            .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book))
            .ForMember(dest => dest.ShoppingCart, opt => opt.MapFrom(src => src.ShoppingCart));
    }
}