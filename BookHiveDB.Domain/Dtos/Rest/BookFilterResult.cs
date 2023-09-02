using BookHiveDB.Domain.Dtos.REST.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHiveDB.Domain.Dtos.Rest
{
    public class BookFilterResult
    {
        public List<BookDto> BookDtos { get; set; }
        public int TotalBooksCount { get; set; }
    }
}
