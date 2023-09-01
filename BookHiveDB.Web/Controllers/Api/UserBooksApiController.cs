using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.Dtos.Rest.Library;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Api;

[Route("api/my-library")]
[ApiController]
public class UserBooksApiController : ControllerBase
{
    private readonly IUserBookService _userBookService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserBooksApiController(IUserBookService userBookService, IMapper mapper, IUserService userService)
    {
        _userBookService = userBookService;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet]
    [Authorize("Default")]
    public IActionResult GetUserBooks()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var books = _userBookService.FindByUser(user);
        var bookDtos = _mapper.Map<List<UserBookDto>>(books);

        return Ok(bookDtos);
    }

    [HttpPost]
    [Authorize("Default")]
    public IActionResult AddBooksToLibrary([FromBody] AddBooksToLibraryRequest addBooksToLibraryRequest)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        addBooksToLibraryRequest.BookIds.ForEach(bookId => _userBookService.addBookToMyBooks(userId, bookId));

        return Ok();
    }

    [HttpPut]
    [Authorize("Default")]
    public IActionResult EditLastPageRead([FromBody] EditLastPageReadResponse editLastPageReadResponse)
    {
        _userBookService.editLastPageReadForBook(editLastPageReadResponse.UserId, editLastPageReadResponse.BookId,
            editLastPageReadResponse.LastPageRead);

        return Ok();
    }
}
