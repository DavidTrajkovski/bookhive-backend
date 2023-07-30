﻿using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.Dtos.REST.Author;
using BookHiveDB.Domain.Dtos.REST.Book;
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
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(
                    src => src.Genres.Select(g => g.ToString())));
    }
}