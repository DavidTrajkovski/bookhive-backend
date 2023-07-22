using BookHiveDB.Domain.DTO.REST;
using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookHiveDB.Domain.DTO.REST.Book;

namespace BookHiveDB.Domain.DTO.REST
{
    public class BookGenreDTO : BaseEntity
    {
        public Guid BookId { get; set; }
        public BookDto Book { get; set; }
        public Guid GenreId { get; set; }
        public GenreDTO Genre { get; set; }
    }
}
