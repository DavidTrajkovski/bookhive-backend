using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHiveDB.Domain.Dtos.Rest.Book
{
    public class BookPdfUrl
    {
        public Guid Id { get; set; }
        public string PdfUrl { get; set; }
    }
}
