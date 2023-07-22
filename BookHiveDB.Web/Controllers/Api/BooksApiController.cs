using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.DTO.REST.Book;
using BookHiveDB.Domain.Enumerations;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Web.Controllers.Api
{
    [ApiController]
    [Route("api/books")]
    public class BooksRestController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IMapper _mapper;

        public BooksRestController(IBookService bookService, IAuthorService authorService, IMapper mapper)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            _mapper = mapper;
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

            var bookDto = _mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookDto createBookDto)
        {
            var authors = createBookDto.AuthorIds.Select((authorId) => authorService.findById(authorId));

            var newBook = _mapper.Map<Book>(createBookDto);
            newBook.Authors.AddRange(authors);
            newBook.Genres.AddRange(new [] { Genre.CRIME , Genre.DRAMA});
            var newlyCreatedBook = bookService.CreateNewBook(newBook);

            var bookDto = _mapper.Map<BookDto>(newlyCreatedBook);
            // Don't return newBook, return a DTO
            return Ok(bookDto);
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
