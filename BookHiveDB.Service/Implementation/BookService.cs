using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO;
using BookHiveDB.Domain.Relations;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookHiveDB.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository BookRepository;
        private readonly IRepository<BookInShoppingCart> _bookInShoppingCartRepository;
        private readonly IRepository<Author> authorRepository;
        private readonly IUserRepository userRepository;

        public BookService(IBookRepository BookRepository, IRepository<Author> _authorRepository, IUserRepository userRepository, IRepository<BookInShoppingCart> bookInShoppingCartRepository)
        {
            this.BookRepository = BookRepository;
            this.authorRepository = _authorRepository;
            this.userRepository = userRepository;
            this._bookInShoppingCartRepository = bookInShoppingCartRepository;

        }

        public Book add(string isbn, string name, string description, string ciu, DateTime datePublished, List<Guid> authorIds, List<Genre> genres)
        {
            Book book = new Book
            {
                isbn = isbn,
                name = name,
                description = description,
                coverImageUrl = ciu,
                datePublished = datePublished
            };

            BookRepository.Insert(book);


            List<Author> authors = new List<Author>();
            foreach(Guid guid in authorIds)
            {
                authors.Add(authorRepository.Get(guid));
            }
            List<AuthorBook> authorBooks = new List<AuthorBook>();
            foreach(Author author in authors)
            {
                authorBooks.Add(new AuthorBook { Author = author, AuthorId = author.Id, Book = book, BookId = book.Id });
            }

            book.authorBooks = authorBooks;

            List<BookGenre> bookGenres = new List<BookGenre>();
            foreach(Genre genre in genres)
            {
                bookGenres.Add(new BookGenre { Genre = genre, GenreId = genre.Id, Book = book, BookId = book.Id });
            }
            book.BookGenres = bookGenres;
            BookRepository.Update(book);
            return book;
            
        }

        public void deleteById(Guid id)
        {
            Book book = BookRepository.Get(id);
            BookRepository.Delete(book);
        }

        public Book edit(Guid id, string isbn, string name, string description, string ciu, DateTime datePublished, List<Guid> authorIds, List<Genre> genres)
        {
            Book book = BookRepository.Get(id);
            book.isbn = isbn;
            book.name = name;
            book.description = description;
            book.coverImageUrl = ciu;
            book.datePublished = datePublished;

            List<Author> authors = new List<Author>();
            foreach (Guid guid in authorIds)
            {
                authors.Add(authorRepository.Get(guid));
            }
            List<AuthorBook> authorBooks = new List<AuthorBook>();
            foreach (Author author in authors)
            {
                authorBooks.Add(new AuthorBook { Author = author, AuthorId = author.Id, Book = book, BookId = book.Id });
            }
            book.authorBooks = authorBooks;

            List<BookGenre> bookGenres = new List<BookGenre>();
            foreach (Genre genre in genres)
            {
                bookGenres.Add(new BookGenre { Genre = genre, GenreId = genre.Id, Book = book, BookId = book.Id });
            }
            book.BookGenres = bookGenres;

            BookRepository.Update(book);

            return book;

        }

        public Book Update(Book book)
        {
            BookRepository.Update(book);
            return book;
        }

        public List<Book> findAll()
        {
            return BookRepository.GetAll();
        }

        public Book findById(Guid id)
        {
            return BookRepository.Get(id);
        }

        public Book CreateNewBook(Book Book)
        {
            BookRepository.Insert(Book);
            return Book;
        }

        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this.userRepository.Get(userID);

            var userShoppingCard = user.UserCart;

            if (userShoppingCard == null) return false;
            
            var book = this.findById(item.BookId);


            if (book == null) return false;
            
            BookInShoppingCart itemToAdd = new BookInShoppingCart
            {
                Id = Guid.NewGuid(),
                Book = book,
                BookId = book.Id,
                ShoppingCart = userShoppingCard,
                ShoppingCartId = userShoppingCard.Id,
                Quantity = item.Quantity
            };

            var existing = userShoppingCard.BookInShoppingCarts.Where(z => z.ShoppingCartId == userShoppingCard.Id && z.BookId == itemToAdd.BookId).FirstOrDefault();

            if (existing != null)
            {
                existing.Quantity += itemToAdd.Quantity;
                this._bookInShoppingCartRepository.Update(existing);

            }
            else
            {
                this._bookInShoppingCartRepository.Insert(itemToAdd);
            }
            return true;
        }

        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var book = this.findById(id.Value);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                Book = book,
                BookId = book.Id,
                Quantity = 1
            };
            return model;
        }
    }
}
