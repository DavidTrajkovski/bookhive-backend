using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.Dtos.Rest.BookShop;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Api;

[ApiController]
[Route("api/bookshops")]
public class BookShopsApiController : ControllerBase
{
    private readonly IBookShopService _bookShopService;
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BookShopsApiController(IBookShopService bookShopService, IBookService bookService, IMapper mapper)
    {
        _bookShopService = bookShopService;
        _bookService = bookService;
        _mapper = mapper;
    }


    [HttpGet("book/{bookId:guid}")]
    public IActionResult GetBookShopsByBook(Guid bookId)
    {
        var bookShopsByBook = _bookShopService.getAllByBooks(bookId);
        var bookShopDtos = _mapper.Map<List<BookShopDto>>(bookShopsByBook);

        return Ok(bookShopDtos);
    }

    [HttpGet]
    public IActionResult GetAllBookShops()
    {
        var bookShops = _bookShopService.GetAll();

        return Ok(bookShops);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBookShopById(Guid id)
    {
        var bookShop = _bookShopService.Get(id);

        if (bookShop is null) return NotFound();

        return Ok(bookShop);
    }

    [HttpPost]
    public IActionResult CreateBookShop([FromBody] CreateBookShopDto createBookShopDto)
    {
        var newBookShop = _mapper.Map<BookShop>(createBookShopDto);
        _bookShopService.Insert(newBookShop);
        var bookShopDto = _mapper.Map<BookShopDto>(newBookShop);

        return Ok(bookShopDto);
    }

    [HttpPost("add-books")]
    public IActionResult AddBooksToBookShop([FromBody] AddBooksToBookShopDto addBooksToBookShopDto)
    {
        var bookShop = _bookShopService.Get(addBooksToBookShopDto.BookShopId);
        var books = addBooksToBookShopDto.BookIds.Select(book => _bookService.findById(book));
        bookShop.Books.AddRange(books);
        _bookShopService.Update(bookShop);

        var bookShopDto = _mapper.Map<BookShopDto>(bookShop);

        return Ok(bookShopDto);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateBookShop(Guid id, [FromBody] BookShop updatedBookShop)
    {
        var existingBookShop = _bookShopService.Get(id);
        if (existingBookShop is null) return NotFound();

        existingBookShop.address = updatedBookShop.address;
        existingBookShop.city = updatedBookShop.city;
        existingBookShop.name = updatedBookShop.name;
        existingBookShop.bookshopEmail = updatedBookShop.bookshopEmail;
        existingBookShop.phoneNumber = updatedBookShop.phoneNumber;
        existingBookShop.websiteLink = updatedBookShop.websiteLink;
        existingBookShop.latitude = updatedBookShop.latitude;
        existingBookShop.longitude = updatedBookShop.longitude;
        existingBookShop.grade = updatedBookShop.grade;
        existingBookShop.numGraders = updatedBookShop.numGraders;

        _bookShopService.Update(existingBookShop);

        return Ok(existingBookShop);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBookShop(Guid id)
    {
        var bookShop = _bookShopService.Get(id);

        if (bookShop is null) return NotFound();

        _bookShopService.DeleteById(id);

        return Ok();
    }
}
