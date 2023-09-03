using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookHiveDB.Domain.Dtos.Rest.ShoppingCart;
using BookHiveDB.Domain.Models;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace BookHiveDB.Web.Controllers.Api;

[Route("api/shopping-cart")]
[ApiController]
public class ShoppingCartApiController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IMapper _mapper;
    private readonly IBookService _bookService;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public ShoppingCartApiController(IShoppingCartService shoppingCartService, IUserService userService, IMapper mapper,
        IBookService bookService, IConfiguration configuration,
        IEmailService emailService)
    {
        _shoppingCartService = shoppingCartService;
        _userService = userService;
        _mapper = mapper;
        _bookService = bookService;
        _configuration = configuration;
        _emailService = emailService;
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

    [HttpPost("create-payment-intent")]
    [Authorize("Default")]
    public async Task<IActionResult> CreatePaymentIntent([FromBody] PaymentRequest paymentRequest)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var options = new PaymentIntentCreateOptions
        {
            Amount = paymentRequest.Amount * 100,
            Currency = "EUR"
        };

        var secretKey = _configuration.GetSection("Stripe").GetSection("SecretKey").Value;
        var client = new StripeClient(secretKey);
        var service = new PaymentIntentService(client);
        var paymentIntent = await service.CreateAsync(options);

        var receipt = new EmailMessage
        {
            Content = "Thank you for purchasing an e-book on BookHive!",
            Id = Guid.NewGuid(),
            MailTo = "markospasenovski00@gmail.com",
            Status = true,
            Subject = "Payment Confirmation"
        };

        await _emailService.SendEmailAsync(receipt);

        return Ok(new { client_secret = paymentIntent.ClientSecret });
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

    [HttpDelete("clear")]
    [Authorize("Default")]
    public IActionResult ClearShoppingCart()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        if (string.IsNullOrEmpty(userId)) return BadRequest("Invalid token, ID claim is empty.");

        var user = _userService.findById(userId);
        if (user is null) return NotFound("User not found");

        var shoppingCart = _shoppingCartService.getShoppingCartInfo(userId);
        var books = shoppingCart.BookInShoppingCarts;

        books.ForEach(b => _shoppingCartService.deleteBookFromShoppingCart(userId, b.BookId));

        return Ok();
    }
}
