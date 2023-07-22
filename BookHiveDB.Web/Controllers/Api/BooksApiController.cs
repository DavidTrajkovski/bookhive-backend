using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookHiveDB.Domain.Relations;
using BookHiveDB.Service.Implementation;
using System.Linq;
using BookHiveDB.Repository.Startup;

namespace BookHiveDB.Web.Controllers.Api
{
    [ApiController]
    [Route("api/books")]
    public class BooksRestController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IGenreInitializer genreInitializer;

        public BooksRestController(IBookService bookService, IAuthorService authorService, IGenreInitializer genreInitializer)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.genreInitializer = genreInitializer;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            List<Book> books = bookService.findAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            Book book = bookService.findById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book, [FromQuery] List<Guid> authors, [FromQuery] List<Guid> genres)
        {
            book.Id = Guid.NewGuid();
            book.authorBooks = new List<AuthorBook>();
            book.BookGenres = new List<BookGenre>();

            foreach (var author in authors.Select(authorGuid => authorService.findById(authorGuid)))
            {
                book.authorBooks.Add(new AuthorBook { Author = author, AuthorId = author.Id, Book = book, BookId = book.Id });
            }

            foreach (var genre in genres.Select(genreGuid => genreInitializer.GetById(genreGuid)))
            {
                book.BookGenres.Add(new BookGenre { Genre = genre, GenreId = genre.Id, Book = book, BookId = book.Id });
            }

            bookService.CreateNewBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        

        [HttpPost("{id}")]
        public IActionResult UpdateBook(Guid id, [FromBody] Book book)
        {
            Book existingBook = bookService.findById(id);
            if (existingBook == null)
                return NotFound();

            book.Id = existingBook.Id;
            Book updatedBook = bookService.Update(book);
            return Ok(updatedBook);
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            Book existingBook = bookService.findById(id);
            if (existingBook == null)
                return NotFound();

            bookService.deleteById(id);
            return Ok();
        }
    }
}
