using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.DTO.REST.Book;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Web.AutoMapper;

public class BookHiveAutoMapperProfile : Profile
{
    public BookHiveAutoMapperProfile()
    {
        CreateMap<CreateBookDto, Book>();
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(
                    src => src.Genres.Select(g => g.ToString())));
    }
}
