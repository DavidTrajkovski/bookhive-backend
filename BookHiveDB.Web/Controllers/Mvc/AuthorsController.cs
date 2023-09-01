using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BookHiveDB.Domain.Dtos.Mvc;
using BookHiveDB.Domain.Models;
using BookHiveDB.Service.Interface;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHiveDB.Web.Controllers.Mvc
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: Authors
        public IActionResult Index()
        {
            return View(_authorService.findAll());
        }

        // GET: Authors/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var author = _authorService.findById(id.Value);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("name,surname,age,biography,Id")] Author author)
        {
            if (!ModelState.IsValid) return View(author);
            author.Id = Guid.NewGuid();
            _authorService.Insert(author);
            return RedirectToAction(nameof(Index));
        }


        public  IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _authorService.findById(id.Value);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("name,surname,age,biography,Id")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return View(author);
            
            try
            {
                _authorService.Update(author);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(author.Id))
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

     
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _authorService.findById(id.Value);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _authorService.deleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(Guid id)
        {
            return _authorService.findById(id) != null;
        }


        public ActionResult ImportAuthorsView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportAuthors(IFormFile file)
        {
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            List<UserExcelDto> authors = getAllAuthorsFromFile(file.FileName);

            foreach (var author in authors)
            {
                _authorService.add(author.name, author.surname, author.age, author.biography);
            }
            return RedirectToAction("Index"); 
        }

        private List<UserExcelDto> getAllAuthorsFromFile(string fileName)
        {
            List<UserExcelDto> authors = new List<UserExcelDto>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        authors.Add(new UserExcelDto
                        {
                            name = reader.GetValue(0).ToString(),
                            surname = reader.GetValue(1).ToString(),
                            age = Convert.ToInt32(reader.GetValue(2)),
                            biography = reader.GetValue(3).ToString()
                        });
                    }
                }
            }
            return authors;
        }
    }
}
