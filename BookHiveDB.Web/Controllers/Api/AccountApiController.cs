using BookHiveDB.Domain.Dtos.Rest;
using BookHiveDB.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BookHiveDB.Domain.Dtos.Rest.Wishlist;
using BookHiveDB.Service.Interface;
using System;

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
        
        public AccountApiController(UserManager<BookHiveApplicationUser> userManager, SignInManager<BookHiveApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IUserService userService, IBookInWishListService wishListService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _wishListService = wishListService;
            _userService = userService;
        }

        [HttpGet("emails")]
        public IActionResult GetBookHiveUserEmails()
        {
            var emails = _userService.BookHiveUserEmails();
            return Ok(emails);
        }
        
        [HttpPost("edit")]
        //[Authorize("Default")]
        public IActionResult EditProfile([FromBody] UpdateUserDTO userDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.FindByIdAsync(userId).Result;



            if (userDTO.password != null && !userDTO.password.Equals(userDTO.confirmPassword))
            {
                return Unauthorized(new { message = "Passwords do not match." });
            }

            user.FirstName = userDTO.firstName;
            user.LastName = userDTO.lastName;
            user.Address = userDTO.address;
            if (userDTO.password == null)
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
        public IActionResult GetMyWishList(Guid id)
        {
            var myBooks = _wishListService.getAllBookInWishlistForUser(id.ToString());
            return Ok(myBooks);
        }

        [HttpPost("my-wishlist")]
        public IActionResult AddBookToMyWishList([FromBody] WishlistDto wishlistDto)
        {
            _wishListService.addBookToMyWishlist(wishlistDto.UserId, wishlistDto.BookId);
            return Ok();
        }
        
        [HttpDelete("my-wishlist")]
        public IActionResult RemoveBookFromMyWishList([FromBody] WishlistDto wishlistDto)
        {
            _wishListService.removeBookFromMyWishlist(wishlistDto.UserId, wishlistDto.BookId);
            return Ok();
        }
    }
}
