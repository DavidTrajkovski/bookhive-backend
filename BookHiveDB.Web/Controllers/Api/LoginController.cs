using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using BookHiveDB.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO;
using System.Linq;

namespace BookHiveDB.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        private readonly UserManager<BookHiveApplicationUser> _userManager;
        private readonly SignInManager<BookHiveApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IConfiguration _config;

        public LoginController(IConfiguration config, UserManager<BookHiveApplicationUser> userManager, SignInManager<BookHiveApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto login)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private async Task<BookHiveApplicationUser> AuthenticateUser(UserLoginDto model)
        {
            BookHiveApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
            if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
            {
                return null;
            }
            return user;
        }

        private string GenerateJSONWebToken(BookHiveApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Role, roles[0])
        };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
