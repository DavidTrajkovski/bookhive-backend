using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO;
using BookHiveDB.Domain.Relations;
using BookHiveDB.Repository.Startup;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHiveDB.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IGenreInitializer _genreInitializer;
        public BooksController(IBookService bookService, IAuthorService authorService, IGenreInitializer genreInitializer)
        {
            _authorService = authorService;
            _bookService = bookService;
            _genreInitializer = genreInitializer;
        }

        // GET: Books
        public IActionResult Index()
        {
            return View(_bookService.findAll());
        }


        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["authors"] = _authorService.findAll();
            ViewData["genres"] = _genreInitializer.GetAll();
            return View();
        }


        // GET: Books/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.findById(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }


        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("isbn,name,description,datePublished,coverImageUrl,Price,isValid,Id")] Book book, List<Guid> authors, List<Guid> genres)
        {
            if (!ModelState.IsValid) return View(book);
            book.Id = Guid.NewGuid();
            book.authorBooks = new List<AuthorBook>();
            book.BookGenres = new List<BookGenre>();
            
            foreach (var author in authors.Select(authorGuid => _authorService.findById(authorGuid)))
            {
                book.authorBooks.Add(new AuthorBook { Author = author, AuthorId = author.Id, Book = book, BookId = book.Id });
            }
            
            foreach (var genre in genres.Select(genreGuid => _genreInitializer.GetById(genreGuid)))
            {
                book.BookGenres.Add(new BookGenre {Genre = genre, GenreId = genre.Id, Book = book, BookId = book.Id });
            }
            
            _bookService.CreateNewBook(book);
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/5
        public IActionResult Edit(Guid? id)
        {
            ViewData["authors"] = _authorService.findAll();
            ViewData["genres"] = _genreInitializer.GetAll();
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.findById(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("isbn,name,description,datePublished,coverImageUrl,Price,isValid,Id")] Book book, List<Guid> authors, List<Guid> genres)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(book);
            
            try
            {
                var book1 = _bookService.findById(book.Id);
                book1.isbn = book.isbn;
                book1.name = book.name;
                book1.description = book.description;
                book1.datePublished = book.datePublished;
                book1.coverImageUrl = book.coverImageUrl;
                book1.Price = book.Price;
                book1.isValid = book.isValid;



                book1.authorBooks = new List<AuthorBook>();
                book1.BookGenres = new List<BookGenre>();
                
                foreach (var author in authors.Select(authorGuid => _authorService.findById(authorGuid)))
                {
                    book1.authorBooks.Add(new AuthorBook { Author = author, AuthorId = author.Id, Book = book, BookId = book.Id });
                }
                
                foreach (var genre in genres.Select(genreGuid => _genreInitializer.GetById(genreGuid)))
                {
                    book1.BookGenres.Add(new BookGenre { Genre = genre, GenreId = genre.Id, Book = book, BookId = book.Id });
                }
                
                _bookService.Update(book1);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.Id))
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.findById(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _bookService.deleteById(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult AddBookToCart(Guid id)
        {
            var result = _bookService.GetShoppingCartInfo(id);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBookToCart(AddToShoppingCartDto model)
        {


            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _bookService.AddToShoppingCart(model, userId);

            if (result)
            {
                return RedirectToAction("Index", "Books");
            }
            return View(model);
        }

        private bool BookExists(Guid id)
        {
            return _bookService.findById(id) != null;
        }
    }
}
