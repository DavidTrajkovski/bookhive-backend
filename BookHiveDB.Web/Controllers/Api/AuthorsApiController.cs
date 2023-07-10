using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using BookHiveDB.Domain.DomainModels;

namespace BookHiveDB.Web.Controllers.Api
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsApiController : ControllerBase
    {
        private readonly IAuthorService authorService;

        public AuthorsApiController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            List<Author> authors = authorService.findAll();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(Guid id)
        {
            Author author = authorService.findById(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Author createdAuthor = authorService.Insert(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = createdAuthor.Id }, createdAuthor);
        }

        [HttpPost("{id}")]
        public IActionResult UpdateAuthor(Guid id, [FromBody] Author updatedAuthor)
        {
            Author existingAuthor = authorService.findById(id);
            if (existingAuthor == null)
                return NotFound();

            existingAuthor.name = updatedAuthor.name;
            existingAuthor.surname = updatedAuthor.surname;
            existingAuthor.age = updatedAuthor.age;
            existingAuthor.biography = updatedAuthor.biography;

            Author updatedAuthorResult = authorService.Update(existingAuthor);
            return Ok(updatedAuthorResult);
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteAuthor(Guid id)
        {
            Author author = authorService.findById(id);
            if (author == null)
                return NotFound();

            authorService.deleteById(id);
            return Ok("Author deleted successfully.");
        }
    }
}
