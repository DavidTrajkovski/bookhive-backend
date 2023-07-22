using System.Diagnostics;
using BookHiveDB.Domain;
using BookHiveDB.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Mvc
{
    public class HomeController : Controller
    {
        public IActionResult Index(string returnUrl)
        {
            var model = new UserLoginDto { ReturnUrl = returnUrl };

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
