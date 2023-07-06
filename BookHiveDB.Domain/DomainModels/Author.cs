using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Domain.DomainModels
{
    public class Author : BaseEntity
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string biography { get; set; }

        public virtual ICollection<AuthorBook> authorBooks { get; set; }
    }
}
