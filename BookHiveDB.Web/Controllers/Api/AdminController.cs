using BookHiveDB.Domain;
using BookHiveDB.Domain.DomainModels;
using BookHiveDB.Domain.DTO;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHiveDB.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<BookHiveApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public AdminController(IOrderService orderService, UserManager<BookHiveApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _orderService = orderService;
            _userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            var result = this._orderService.getAllOrders();
            return result;
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            var result = this._orderService.getOrderDetails(model);
            return result;
        }



        [HttpPost("[action]")]
        public async Task<bool> ImportAllUsers(List<UserRegistrationDto> model)
        {
            bool status = true;
            foreach (var item in model)
            {
                var userCheck = _userManager.FindByEmailAsync(item.Email).Result;
                if (userCheck == null)
                {
                    var user = new BookHiveApplicationUser
                    {
                        FirstName = item.Name,
                        LastName = item.LastName,
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        EmailConfirmed = true,
                        UserCart = new ShoppingCart()
                    };
                    var result = _userManager.CreateAsync(user, item.Password).Result;


                    if (result.Succeeded)
                    {
                        var roleExist = await roleManager.RoleExistsAsync("StandardUser");
                        if (!roleExist)
                        {
                            await roleManager.CreateAsync(new IdentityRole("StandardUser"));
                        }
                        await _userManager.AddToRoleAsync(user, "StandardUser");
                    }



                    status = status & result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return status;
        }
    }
}
