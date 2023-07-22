using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Repository;
using BookHiveDB.Service.Interface;
using BookHiveDB.Service.Implementation;

namespace BookHiveDB.Web.Controllers
{

    [ApiController]
    [Route("api/bookshops")]
    // Error may be thrown in views: /api/bookshops vs /api/bookshop
    public class BookShopsApiController : ControllerBase
    {
        private readonly IBookShopService bookShopService;



        public BookShopsApiController(IBookShopService bookShopService)
        {
            this.bookShopService = bookShopService;
        }


        [HttpGet("[action]")]
        public List<BookShop> getBookShopsByBook(Guid id)
        {
            return bookShopService.getAllByBooks(id);
        }

        [HttpGet]
        public IActionResult GetAllBookShops()
        {
            List<BookShop> bookShops = bookShopService.GetAll();
            return Ok(bookShops);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookShopById(Guid id)
        {
            BookShop bookShop = bookShopService.Get(id);
            if (bookShop == null)
                return NotFound();

            return Ok(bookShop);
        }

        [HttpPost]
        public IActionResult CreateBookShop([FromBody] BookShop bookShop)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bookShopService.Insert(bookShop);
            return CreatedAtAction(nameof(GetBookShopById), new { id = bookShop.Id }, bookShop);
        }

        [HttpPost("{id}")]
        public IActionResult UpdateBookShop(Guid id, [FromBody] BookShop updatedBookShop)
        {
            BookShop existingBookShop = bookShopService.Get(id);
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

            bookShopService.Update(existingBookShop);
            return Ok(existingBookShop);
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteBookShop(Guid id)
        {
            BookShop bookShop = bookShopService.Get(id);
            if (bookShop == null)
                return NotFound();

            bookShopService.DeleteById(id);
            return Ok("Book shop deleted successfully.");
        }
    }
}
