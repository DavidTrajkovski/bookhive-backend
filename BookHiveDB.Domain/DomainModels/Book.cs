using BookHiveDB.Domain.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookHiveDB.Domain.DomainModels
{
    public class Book : BaseEntity
    {
        public string isbn { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        [DataType(DataType.Date)]
        public DateTime datePublished { get; set; }
        public string coverImageUrl { get; set; }
        public double Price { get; set; }
        public int totalPages { get; set; }
        public bool isValid { get; set; }
        public virtual ICollection<UserBook> userBooks { get; set; }
        public virtual ICollection<AuthorBook> authorBooks { get; set; }
        public virtual ICollection<BookInOrder> BooksInOrders { get; set; }
        public virtual ICollection<BookInShoppingCart> BookInShoppingCarts { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<BookInWishList> BookInWishLists { get; set; }
        public virtual ICollection<BookInBookShop> BookInBookShops { get; set; }

    }
}
