using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Dtos.REST.Author;
using BookHiveDB.Domain.Dtos.REST.Book;
using BookHiveDB.Domain.Dtos.Rest.BookShop;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Web.AutoMapper;

public class BookHiveAutoMapperProfile : Profile
{
    public BookHiveAutoMapperProfile()
    {
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

        // BookShop
        CreateMap<CreateBookShopDto, BookShop>();
        CreateMap<BookShop, BookShopDto>();
    }
}
