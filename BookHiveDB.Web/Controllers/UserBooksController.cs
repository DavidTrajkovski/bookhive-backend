using System;
using System.Security.Claims;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers
{
    public class UserBooksController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserBookService _userBookService;
        private readonly IBookService _bookService;


        public UserBooksController(IUserBookService userBookService, IUserService userService, IBookService bookService)
        {
            _userBookService = userBookService;
            _userService = userService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userService.findById(userId);
            return View(_userBookService.FindByUser(user));
        }

        public IActionResult Create(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _userBookService.addBookToMyBooks(userId, id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid bookId, int lastPage)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _userBookService.editLastPageReadForBook(userId, bookId, lastPage);

            var user = _userService.findById(userId);
            var book = _bookService.findById(bookId);
            var userbook = _userBookService.FindByUserAndBook(user, book);

            userbook.lastPageRead = lastPage > book.totalPages ? book.totalPages : lastPage;
            _userBookService.Update(userbook);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            var obj = _userBookService.Get(id);
            return View(obj);
        }

        public IActionResult DeleteConfirmed(Guid id)
        {
            _userBookService.RemoveFromMyBooks(id);
            return RedirectToAction("Index");
        }
    }
}