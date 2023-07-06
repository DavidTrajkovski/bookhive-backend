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

namespace BookHiveDB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookShopApiController : ControllerBase
    {
        private readonly IBookShopService bookshopService;

        public BookShopApiController(IBookShopService bookshopService)
        {
            this.bookshopService = bookshopService;
        }

        [HttpGet("[action]")]
        public List<BookShop> getBookShopsByBook(Guid id)
        {
            return bookshopService.getAllByBooks(id);
        }

    }
}
