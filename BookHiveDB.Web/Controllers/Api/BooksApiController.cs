using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.Dtos.REST.Book;
using BookHiveDB.Domain.Enumerations;
using BookHiveDB.Domain.Models;
using Irony.Parsing;
using BookHiveDB.Domain.Dtos.Rest.Book;

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

    [HttpGet("filter")]
    public IActionResult GetBooksByCriteria(int page = 1, int pageSize = 10, string nameSearch = "", [FromQuery(Name = "genres")] List<string> genres = null)
    {
        try
        {
            var bookDtos = _bookService.GetBooksByCriteria(page, pageSize, nameSearch, genres);
            return Ok(bookDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while retrieving books.");
        }
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _bookService.findAll();
        var bookDtos = _mapper.Map<List<BookDto>>(books);
        return Ok(bookDtos);
    }

    [HttpGet("genres")]
    public IActionResult GetAllGenres()
    {
        var genres = _bookService.findAllGenres();
        return Ok(genres);
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


    [HttpGet("{bookId:guid}/preview")]
    public IActionResult GetBookPdfUrl(Guid bookId)
    {
        var book = _bookService.findById(bookId);

        if (book == null)
            return NotFound();

        BookPdfUrl bookPdfUrl = new BookPdfUrl();
        bookPdfUrl.Id = book.Id;
        bookPdfUrl.PdfUrl = book.PdfUrl;

        return Ok(bookPdfUrl);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] CreateBookDto createBookDto)
    {
        var authors = createBookDto.AuthorIds.Select((authorId) => _authorService.findById(authorId));

        var newBook = _mapper.Map<Book>(createBookDto);
        newBook.Authors.AddRange(authors);
        List<Genre> Genres = new List<Genre>();

        foreach (string genreString in createBookDto.Genres)
        {
            if (Enum.TryParse(genreString, out Genre genreEnum))
            {
                Genres.Add(genreEnum);
            }
        }
        newBook.Genres = Genres;

        newBook.DatePublished = DateTime.SpecifyKind(createBookDto.DatePublished, DateTimeKind.Utc);

        var newlyCreatedBook = _bookService.CreateNewBook(newBook);

        var bookDto = _mapper.Map<BookDto>(newlyCreatedBook);

        return Ok(bookDto);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateBook(Guid id, [FromBody] CreateBookDto createBookDto)
    {
        var existingBook = _bookService.findById(id);
        if (existingBook == null)
            return NotFound();

        // Update existingBook's properties with data from createBookDto
        existingBook.Isbn = createBookDto.Isbn;
        existingBook.Name = createBookDto.Name;
        existingBook.Description = createBookDto.Description;
        existingBook.DatePublished = DateTime.SpecifyKind(createBookDto.DatePublished, DateTimeKind.Utc);
        existingBook.CoverImageUrl = createBookDto.CoverImageUrl;
        existingBook.PdfUrl = createBookDto.PdfUrl;
        existingBook.Price = createBookDto.Price;
        existingBook.TotalPages = createBookDto.TotalPages;

        // Update existingBook's authors
        var authors = createBookDto.AuthorIds.Select((authorId) => _authorService.findById(authorId));
        existingBook.Authors.Clear(); // Clear existing authors
        existingBook.Authors.AddRange(authors);

        // Update existingBook's genres
        List<Genre> updatedGenres = new List<Genre>();
        foreach (string genreString in createBookDto.Genres)
        {
            if (Enum.TryParse(genreString, out Genre genreEnum))
            {
                updatedGenres.Add(genreEnum);
            }
        }
        existingBook.Genres = updatedGenres;

        // Update the existing book in the database
        var updatedBook = _bookService.Update(existingBook);
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
