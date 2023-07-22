using System;
using System.Security.Claims;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace BookHiveDB.Web.Controllers.Mvc
{
    public class ShoppingCartController : Controller
    {

        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService service)
        {
            _shoppingCartService = service;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_shoppingCartService.getShoppingCartInfo(userId));
        }

        public IActionResult DeleteBookFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            _shoppingCartService.deleteBookFromShoppingCart(userId, id);

            return RedirectToAction("Index", "ShoppingCart");
        }

        public bool OrderNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _shoppingCartService.order(userId);

            return result;
        }

        public IActionResult PayNow(String stripeEmail, string stripeToken)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = _shoppingCartService.getShoppingCartInfo(userId);

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (Convert.ToInt32(order.TotalPrice) * 100),
                Description = "EShop BookHiveDB Application Payment",
                Currency = "usd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded")
            {
                var result = OrderNow();

                if (result)
                {
                    return RedirectToAction("Index", "ShoppingCart");
                }

                return RedirectToAction("Index", "ShoppingCart");
            }

            return RedirectToAction("Index", "ShoppingCart");
        }

    }
}
