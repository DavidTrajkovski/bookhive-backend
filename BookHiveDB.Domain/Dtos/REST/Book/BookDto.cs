
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookHiveDB.Domain.Enumerations;

namespace BookHiveDB.Domain.DTO.REST.Book
{
    public class BookDto : BaseEntity
    {
        public string Isbn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DatePublished { get; set; }
        public string CoverImageUrl { get; set; }
        public double Price { get; set; }
        public int TotalPages { get; set; }
        public bool IsValid { get; set; }
        public List<string> Genres { get; set; }
    }

}
