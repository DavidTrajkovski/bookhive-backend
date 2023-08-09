// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using BookHiveDB.Domain.DomainModels;
// using BookHiveDB.Domain.DTO;
// using BookHiveDB.Domain.Relations;
// using BookHiveDB.Repository.Interface;
// using BookHiveDB.Repository.Startup;
// using BookHiveDB.Service.Interface;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
//
// namespace BookHiveDB.Web.Controllers
// {
//     public class TestController : Controller
//     {
//         private readonly IAuthorService _authorService;
//         private readonly IBookService _bookService;
//         private readonly IGenreInitializer _genreInitializer;
//         private readonly IShoppingCartService _shoppingCartService;
//         private readonly IUserRepository _userRepository;
//         private readonly IBookShopRepository _bookShopRepository;
//
//
//         private readonly RoleManager<IdentityRole> _roleManager;
//
//         public TestController(RoleManager<IdentityRole> roleManager, IBookShopRepository bookShopRepository,
//             IUserRepository userRepository, IShoppingCartService shoppingCartService, IAuthorService authorService,
//             IBookService bookService,
//             IGenreInitializer genreInitializer)
//         {
//             _roleManager = roleManager;
//             _bookShopRepository = bookShopRepository;
//             _userRepository = userRepository;
//             _authorService = authorService;
//             _bookService = bookService;
//             _genreInitializer = genreInitializer;
//             _shoppingCartService = shoppingCartService;
//         }
//
//         public IActionResult Home()
//         {
//             return View();
//         }
//
//         public async Task<IActionResult> Index()
//         {
//             var roleExist = await _roleManager.RoleExistsAsync("Administrator");
//             if (!roleExist)
//             {
//                 await _roleManager.CreateAsync(new IdentityRole("Administrator"));
//             }
//
//
//             var user = _userRepository.Get("12b20786-08b1-47e1-97e1-10a45e66d045");
//
//             var author = _authorService.add("nameofauthor", "surnameofauthor", 55, "some author biography added");
//             var author2 = _authorService.add("OTHERAUTHOR", "surnameofauthor", 55, "some author biography added");
//
//             _authorService.edit(author.Id, author.Name, author.Surname, 1000, author.Biography);
//             var author1 = _authorService.findById(author.Id);
//             var book = _bookService.findAll()[0];
//             book.Name = "Testing book name";
//             _bookService.Update(book);
//
//             var bookshops = _bookShopRepository.getAllByBooks(book);
//
//             var listAuthorGuids = new List<Guid>
//             {
//                 author1.Id,
//                 author2.Id
//             };
//
//             var genres = new List<Genre>();
//             var genre = new Genre { GenreName = "RomanceTEST" };
//             var genre2 = new Genre { GenreName = "ActionTEST" };
//             genres.Add(genre);
//             genres.Add(genre2);
//             _genreInitializer.Insert(genre);
//             _genreInitializer.Insert(genre2);
//
//             var book2 = _bookService.add("1234isbn123", "newbookname", "new book desc", "https://someaddress.com",
//                 DateTime.Now, listAuthorGuids, genres);
//             var bookShop = new BookShop { name = "Test bookshop" };
//             var bookInBookShops = new List<BookInBookShop>
//             {
//                 new() { Book = book2, BookId = book2.Id, BookShop = bookShop, BookShopId = bookShop.Id }
//             };
//             bookShop.BookInBookShops = bookInBookShops;
//             _bookShopRepository.Insert(bookShop);
//
//             _authorService.Update(author1);
//
//             _bookService.AddToShoppingCart(new AddToShoppingCartDto { Book = book2, BookId = book2.Id, Quantity = 5 },
//                 user.Id);
//             _shoppingCartService.order("12b20786-08b1-47e1-97e1-10a45e66d045");
//
//             return View("Home");
//         }
//     }
// }

namespace BookHiveDB.Web.Controllers.Mvc;