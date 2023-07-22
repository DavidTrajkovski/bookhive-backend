using System;
using System.Collections.Generic;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Api;

[ApiController]
[Route("api/bookshops")]
public class BookShopsApiController : ControllerBase
{
    private readonly IBookShopService _bookShopService;

    public BookShopsApiController(IBookShopService bookShopService)
    {
        _bookShopService = bookShopService;
    }


    [HttpGet("[action]")]
    public List<BookShop> GetBookShopsByBook(Guid bookId)
    {
        return _bookShopService.getAllByBooks(bookId);
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
        if (bookShop == null)
            return NotFound();

        return Ok(bookShop);
    }

    [HttpPost]
    public IActionResult CreateBookShop([FromBody] BookShop bookShop)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _bookShopService.Insert(bookShop);
        return CreatedAtAction(nameof(GetBookShopById), new { id = bookShop.Id }, bookShop);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateBookShop(Guid id, [FromBody] BookShop updatedBookShop)
    {
        var existingBookShop = _bookShopService.Get(id);
        if (existingBookShop == null)
            return NotFound();

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
        if (bookShop == null)
            return NotFound();

        _bookShopService.DeleteById(id);
        return Ok("Book shop deleted successfully.");
    }
}
