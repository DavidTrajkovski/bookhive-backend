using AutoMapper;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO.REST;

namespace BookHiveDB.Web.AutoMapper;

public class BookHiveAutoMapperProfile : Profile
{
    public BookHiveAutoMapperProfile()
    {
        CreateMap<Author, AuthorDTO>();
    }
}
