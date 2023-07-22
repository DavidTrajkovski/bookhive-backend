
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookHiveDB.Domain.DTO.REST
{
    public class BookDTO : BaseEntity
    {
        public string isbn { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime datePublished { get; set; }
        public string coverImageUrl { get; set; }
        public double Price { get; set; }
        public int totalPages { get; set; }
        public bool isValid { get; set; }
        
    }

}
