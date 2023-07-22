using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BookHiveDB.Domain;
using BookHiveDB.Domain.Identity;
using BookHiveDB.Service.Interface;
using GemBox.Document;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookHiveDB.Web.Controllers.Mvc
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly UserManager<BookHiveApplicationUser> _userManager;


        public OrderController(IOrderService orderService, UserManager<BookHiveApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.FindByIdAsync(userId).Result;
            var orders = _orderService.getAllOrders();

            if (_userManager.IsInRoleAsync(user, "Administrator").Result)
            {
                return View(orders);
            }
            // if not administrator show only his orders
            foreach (var order in orders.ToList().Where(order => !order.UserId.Equals(userId)))
            {
                orders.Remove(order);
            }
            return View(orders);
        }

        public IActionResult Details(Guid id)
        {
            var baseEntity = new BaseEntity { Id = id };
            var order = _orderService.getOrderDetails(baseEntity);
            return View(order);
        }

        public IActionResult CreateInvoice(Guid id)
        {
            var baseEntity = new BaseEntity { Id = id };
            var order = _orderService.getOrderDetails(baseEntity);


            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");

            var document = DocumentModel.Load(templatePath);

            document.Content.Replace("{{OrderNumber}}", order.Id.ToString());
            document.Content.Replace("{{UserName}}", order.User.UserName);


            var sb = new StringBuilder();
            var totalPrice = 0.0;
            foreach(var bookInOrder in order.BooksInOrders)
            {
                sb.AppendLine(bookInOrder.Book.Name + " with quantity of: " + bookInOrder.Quantity + " and price of: " + bookInOrder.Book.Price + " dollars");
                totalPrice += bookInOrder.Quantity * bookInOrder.Book.Price;
            }

            document.Content.Replace("{{BookList}}", sb.ToString());
            document.Content.Replace("{{TotalPrice}}", totalPrice + "$");

            var stream = new MemoryStream();
            document.Save(stream, new PdfSaveOptions());
            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }
    }
}
