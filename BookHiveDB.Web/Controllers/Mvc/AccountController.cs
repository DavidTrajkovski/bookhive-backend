using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO;
using BookHiveDB.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Mvc
{
    public class AccountController : Controller
    {
        private readonly UserManager<BookHiveApplicationUser> _userManager;
        private readonly SignInManager<BookHiveApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<BookHiveApplicationUser> userManager, SignInManager<BookHiveApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Profile(bool success, bool error, bool passwordShort)
        {
            if (success)
            {
                ViewData["success"] = true;
            }
            if (error)
            {
                ViewData["error"] = true;
            }
            if (passwordShort)
            {
                ViewData["passwordShort"] = true;
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.FindByIdAsync(userId).Result;

            return View(user);
        }

        public IActionResult EditProfile(string Name, string LastName, string Address, string password, string confirmPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.FindByIdAsync(userId).Result;

            

            if (password !=null &&!password.Equals(confirmPassword))
            {
                return RedirectToAction("Profile", new { error = true });
            }

            user.FirstName = Name;
            user.LastName = LastName;
            user.Address = Address;

            if (password == null)
            {

                var updateResult = _userManager.UpdateAsync(user).Result;
                return RedirectToAction("Profile", new { success = true });
            }



            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            var result = _userManager.ResetPasswordAsync(user, token, password).Result;
            if (!result.Succeeded)
            {
                return RedirectToAction("Profile", new { passwordShort = true });
            }

            var updateResultWithPasswordChange = _userManager.UpdateAsync(user).Result;

            return RedirectToAction("Profile", new { success = true });
        }

        public IActionResult Register()
        {
            UserRegistrationDto model = new UserRegistrationDto();
            return View(model);
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
                        return RedirectToAction("Login");
                    }

                    if (result.Errors.Count() > 0)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("message", error.Description);
                        }
                    }
                    return View(request);
                }

                ModelState.AddModelError("message", "Email already exists.");
                return View(request);
            }
            return View(request);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            UserLoginDto model = new UserLoginDto { ReturnUrl = returnUrl };
            return View("~/Views/Home/Index.cshtml", model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                
                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View("~/Views/Home/Index.cshtml", model);

                }
                if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View("~/Views/Home/Index.cshtml", model);

                }

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    return RedirectToAction("Index", "User");
                }

                ModelState.AddModelError("message", "Invalid login attempt");
                return View("~/Views/Home/Index.cshtml", model);
            }
            return View("~/Views/Home/Index.cshtml", model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult ImportUsers()
        {
            throw new NotImplementedException();
        }

        public IActionResult AddRole()
        {
            throw new NotImplementedException();
        }
    }
}
