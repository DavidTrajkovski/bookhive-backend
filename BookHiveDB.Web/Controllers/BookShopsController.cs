using System;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHiveDB.Web.Controllers
{
    public class BookShopsController : Controller
    {
        private readonly IBookShopService _bookshopService;

        public BookShopsController(IBookShopService bookshopService)
        {
            _bookshopService = bookshopService;
        }


        public IActionResult Index()
        {
            return View(_bookshopService.GetAll());
        }

        public IActionResult Search(string search)
        {
            return View("Index", string.IsNullOrEmpty(search) ? _bookshopService.GetAll() : _bookshopService.findAllByName(search));
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookShop = _bookshopService.Get(id);
            if (bookShop == null)
            {
                return NotFound();
            }

            return View(bookShop);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("address,city,name,bookshopEmail,phoneNumber,websiteLink,latitude,longitude,grade,numGraders,Id")] BookShop bookShop)
        {
            if (!ModelState.IsValid) return View(bookShop);
            bookShop.Id = Guid.NewGuid();
            _bookshopService.Insert(bookShop);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookShop = _bookshopService.Get(id);
            if (bookShop == null)
            {
                return NotFound();
            }
            return View(bookShop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("address,city,name,bookshopEmail,phoneNumber,websiteLink,latitude,longitude,grade,numGraders,Id")] BookShop bookShop)
        {
            if (id != bookShop.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(bookShop);
            
            try
            {
                _bookshopService.Update(bookShop);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookShopExists(bookShop.Id))
                {
                    return NotFound();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookShop = _bookshopService.Get(id);
            if (bookShop == null)
            {
                return NotFound();
            }

            return View(bookShop);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _bookshopService.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Geolocation(Guid id)
        {
            ViewData["bookId"] = id;
            return View();
        }


        private bool BookShopExists(Guid id)
        {
            return _bookshopService.Get(id) != null;
        }
    }
}
