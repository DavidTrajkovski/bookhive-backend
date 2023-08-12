using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using AutoMapper;
using BookHiveDB.Domain.Dtos.REST.Author;
using BookHiveDB.Domain.Models;
using BookHiveDB.Domain.Dtos.REST.Book;

namespace BookHiveDB.Web.Controllers.Api;

[ApiController]
[Route("api/authors")]
public class AuthorsApiController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;

    public AuthorsApiController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet("bookauthorinfo")]
    public IActionResult GetAllBookAuthorInfoDtos()
    {
        var authors = _authorService.findAll();
        var authorDtos = _mapper.Map<List<BookAuthorInfoDto>>(authors);

        return Ok(authorDtos);
    }

    [HttpGet]
    public IActionResult GetAllAuthors()
    {
        var authors = _authorService.findAll();
        var authorDtos = _mapper.Map<List<AuthorDto>>(authors);

        return Ok(authorDtos);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetAuthorById(Guid id)
    {
        var author = _authorService.findById(id);

        if (author == null)
            return NotFound();

        var authorDto = _mapper.Map<AuthorDto>(author);

        return Ok(authorDto);
    }

    [HttpPost]
    public IActionResult CreateAuthor([FromBody] Author author)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdAuthor = _authorService.Insert(author);
        return CreatedAtAction(nameof(GetAuthorById), new { id = createdAuthor.Id }, createdAuthor);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateAuthor(Guid id, [FromBody] Author updatedAuthor)
    {
        var existingAuthor = _authorService.findById(id);
        if (existingAuthor == null)
            return NotFound();

        existingAuthor.Name = updatedAuthor.Name;
        existingAuthor.Surname = updatedAuthor.Surname;
        existingAuthor.Age = updatedAuthor.Age;
        existingAuthor.Biography = updatedAuthor.Biography;

        var updatedAuthorResult = _authorService.Update(existingAuthor);
        return Ok(updatedAuthorResult);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteAuthor(Guid id)
    {
        var author = _authorService.findById(id);
        if (author == null)
            return NotFound();

        _authorService.deleteById(id);
        return Ok("Author deleted successfully.");
    }
}
