using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO;
using BookHiveDB.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using BookHiveDB.Domain.Dtos.Mvc;
using BookHiveDB.Domain.Models;

namespace BookHiveDB.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        private readonly UserManager<BookHiveApplicationUser> _userManager;
        private readonly SignInManager<BookHiveApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterController(UserManager<BookHiveApplicationUser> userManager, SignInManager<BookHiveApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistrationDto request)
        {
            if (ModelState.IsValid)
            {
                var userCheck = await _userManager.FindByEmailAsync(request.Email);
                if (userCheck == null)
                {
                    var user = new BookHiveApplicationUser
                    {
                        FirstName = request.Name,
                        LastName = request.LastName,
                        UserName = request.Email,
                        NormalizedUserName = request.Email,
                        Email = request.Email,
                        EmailConfirmed = true,
                        UserCart = new ShoppingCart()
                    };
                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (result.Succeeded)
                    {
                        var roleExist = await _roleManager.RoleExistsAsync("StandardUser");
                        if (!roleExist)
                        {
                            await _roleManager.CreateAsync(new IdentityRole("StandardUser"));
                        }
                        await _userManager.AddToRoleAsync(user, "StandardUser");
                        return Ok();
                    }

                    if (result.Errors.Count() > 0)
                    {
                        string errorString = "";
                        foreach (var error in result.Errors)
                        {
                            errorString += error;   
                        }
                        return BadRequest(errorString);
                    }
                }

                return BadRequest("Email already exists.");
            }
            return BadRequest("Something went wrong :(");

        }
    }
}
