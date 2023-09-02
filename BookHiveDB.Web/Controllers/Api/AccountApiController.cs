using BookHiveDB.Domain.Dtos.Rest;
using BookHiveDB.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BookHiveDB.Domain.Dtos.Rest.Wishlist;
using BookHiveDB.Service.Interface;
using System;
using System.Linq;
using AutoMapper;
using BookHiveDB.Domain.Dtos.REST.Book;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using BookHiveDB.Domain.Dtos.Rest.BookClub;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {

        private readonly UserManager<BookHiveApplicationUser> _userManager;
        private readonly SignInManager<BookHiveApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IBookInWishListService _wishListService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountApiController(UserManager<BookHiveApplicationUser> userManager, SignInManager<BookHiveApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IUserService userService, IBookInWishListService wishListService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _wishListService = wishListService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("emails")]
        public IActionResult GetBookHiveUserEmails()
        {
            var emails = _userService.BookHiveUserEmails();
            return Ok(emails);
        }

        [HttpGet("user")]
        [Authorize("Default")]
        public IActionResult GetBookHiveUserDetails()
        {

            var userIdClaim = User.Claims.FirstOrDefault(claim => claim.Type == "id");

            if (userIdClaim == null)
            {
                return BadRequest("User ID claim not found.");
            }

            var userId = userIdClaim.Value;
            var user = _userManager.FindByIdAsync(userId).Result;
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpPost("edit")]
        [Authorize("Default")]
        public IActionResult EditProfile([FromBody] UpdateUserDTO userDTO)
        {
            var userIdClaim = User.Claims.FirstOrDefault(claim => claim.Type == "id");

            if (userIdClaim == null)
            {
                return BadRequest("User ID claim not found.");
            }

            var userId = userIdClaim.Value;
            var user = _userManager.FindByIdAsync(userId).Result;



            if (userDTO.password != null && !userDTO.password.Equals(userDTO.confirmPassword))
            {
                return Unauthorized(new { message = "Passwords do not match." });
            }

            user.FirstName = userDTO.firstName;
            user.LastName = userDTO.lastName;
            user.Address = userDTO.address;
            if (userDTO.password.IsNullOrEmpty())
            {
                var updateResult = _userManager.UpdateAsync(user).Result;
                return Ok();
            }



            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            var result = _userManager.ResetPasswordAsync(user, token, userDTO.password).Result;
            if (!result.Succeeded)
            {
                return Ok();
            }

            var updateResultWithPasswordChange = _userManager.UpdateAsync(user).Result;

            return Ok();
        }

        [HttpGet("my-wishlist/{id:guid}")]
        public IActionResult GetBooksInWishlist(Guid id)
        {
            var booksInWishlist = _wishListService.getAllBookInWishlistForUser(id.ToString());
            var books = booksInWishlist.Select(bw => bw.Book).ToList();
            var bookDtos = _mapper.Map<List<BookDto>>(books);

            return Ok(bookDtos);
        }

        [HttpPost("my-wishlist")]
        public IActionResult AddBookToMyWishList([FromBody] WishlistDto wishlistDto)
        {
            _wishListService.addBookToMyWishlist(wishlistDto.UserId, wishlistDto.BookId);
            return Ok();
        }
        
        [HttpDelete("my-wishlist")]
        public IActionResult RemoveBookFromMyWishList([FromQuery] string userId, Guid bookId)
        {
            _wishListService.removeBookFromMyWishlist(userId, bookId);
            return Ok();
        }
    }
}
