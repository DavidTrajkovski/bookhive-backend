using BookHiveDB.Domain.Dtos.Rest;
using BookHiveDB.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BookHiveDB.Service.Interface;

namespace BookHiveDB.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<BookHiveApplicationUser> _userManager;
        private readonly SignInManager<BookHiveApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountApiController(UserManager<BookHiveApplicationUser> userManager, SignInManager<BookHiveApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
    }
}
