using System;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.Dtos.Rest.ShoppingCart;
using BookHiveDB.Domain.Exceptions;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Api;

[Route("api/shopping-cart")]
[ApiController]
public class ShoppingCartApiController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IMapper _mapper;
    private readonly IBookService _bookService;

    public ShoppingCartApiController(IShoppingCartService shoppingCartService, IUserService userService, IMapper mapper,
        IBookService bookService)
    {
        _shoppingCartService = shoppingCartService;
        _userService = userService;
        _mapper = mapper;
        _bookService = bookService;
    }

    [HttpGet]
    [Authorize("Default")]
    public IActionResult GetShoppingCartInfo()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var shoppingCartMvcDto = _shoppingCartService.getShoppingCartInfo(userId);
        var shoppingCartInfoDto = _mapper.Map<ShoppingCartInfoDto>(shoppingCartMvcDto);

        return Ok(shoppingCartInfoDto);
    }

    [HttpPost("add")]
    [Authorize("Default")]
    public IActionResult AddBookToShoppingCart([FromBody] AddToShoppingCartDto addToShoppingCartDto)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var result = _bookService.AddToShoppingCart(addToShoppingCartDto, userId);

        return Ok(result);
    }

    [HttpPost("pay")]
    [Authorize("Default")]
    public IActionResult PayNow()
    {
        // TODO: Impl
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Authorize("Default")]
    public IActionResult RemoveBookFromShoppingCart([FromQuery] Guid bookId)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        _shoppingCartService.deleteBookFromShoppingCart(userId, bookId);

        return Ok();
    }
}
