using System;
using System.Threading.Tasks;
using BookHiveDB.Domain.Dtos.Mvc;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Mvc
{
    public class UserController : Controller
    {

        private readonly IBookInWishListService _bookInWishListService;
        private readonly IBookClubService _bookClubService;
        private readonly UserManager<BookHiveApplicationUser> _userManager;
        private readonly IBookService _bookService;

        public UserController(IBookInWishListService bookInWishListService, IBookClubService bookClubService, UserManager<BookHiveApplicationUser> userManager, IBookService bookService)
        {
            _bookInWishListService = bookInWishListService;
            _bookClubService = bookClubService;
            _userManager = userManager;
            _bookService = bookService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetMyBookClubs()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var myBookClubs = _bookClubService.findByMember(user.Id);
            var obj = new BookClubsLoggedInUser(myBookClubs, user);
            return View(obj);
        }

        public IActionResult LeaveBookClubPage(Guid bookClubId)
        {
            var obj = _bookClubService.findById(bookClubId);
            return View(obj);
            
        }
        public async Task<IActionResult> RemoveBookClubFromMyBookClubsAsync(Guid bookClubId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _bookClubService.removeUserFromBookclub(bookClubId, user.Id);
            return RedirectToAction(nameof(GetMyBookClubs));
        }

        public async Task<IActionResult> AddBookToMyWishList(Guid bookId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _bookInWishListService.addBookToMyWishlist(user.Id, bookId);
            return RedirectToAction(nameof(GetMyWishList));
        }
        public IActionResult RemoveBookPage(Guid bookId)
        {
            var obj = _bookService.findById(bookId);
            return View(obj);
        }

        public async Task<IActionResult> RemoveBookFromMyWishList(Guid bookId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            _bookInWishListService.removeBookFromMyWishlist(user.Id, bookId);
            return RedirectToAction(nameof(GetMyWishList));
        }

        public async Task<IActionResult> GetMyWishList()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var myWishList = _bookInWishListService.getAllBookInWishlistForUser(user.Id);
            return View(myWishList);
        }

    }
}
