using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.Dtos.REST.Book;
using BookHiveDB.Domain.Enumerations;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Web.Controllers.Api;

[ApiController]
[Route("api/books")]
public class BooksRestController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public BooksRestController(IBookService bookService, IAuthorService authorService, IMapper mapper)
    {
        _bookService = bookService;
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _bookService.findAll();
        return Ok(books);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBookById(Guid id)
    {
        var book = _bookService.findById(id);

        if (book == null)
            return NotFound();

        var bookDto = _mapper.Map<BookDto>(book);

        return Ok(bookDto);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] CreateBookDto createBookDto)
    {
        var authors = createBookDto.AuthorIds.Select((authorId) => _authorService.findById(authorId));

        var newBook = _mapper.Map<Book>(createBookDto);
        newBook.Authors.AddRange(authors);
        // TODO: This is TEMPORARY, need to fix the adding of genres logic.
        newBook.Genres.AddRange(new[] { Genre.CRIME, Genre.DRAMA });
        var newlyCreatedBook = _bookService.CreateNewBook(newBook);

        var bookDto = _mapper.Map<BookDto>(newlyCreatedBook);

        return Ok(bookDto);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateBook(Guid id, [FromBody] Book book)
    {
        var existingBook = _bookService.findById(id);
        if (existingBook == null)
            return NotFound();

        book.Id = existingBook.Id;
        var updatedBook = _bookService.Update(book);
        return Ok(updatedBook);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBook(Guid id)
    {
        var existingBook = _bookService.findById(id);
        if (existingBook == null)
            return NotFound();

        _bookService.deleteById(id);
        return Ok();
    }
}
