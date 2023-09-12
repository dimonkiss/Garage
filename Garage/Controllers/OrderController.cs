using DataAccess.Data;
using DataAccess.Entities;
using Garage.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
namespace Garage.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly GarageDbContext _context;

        public OrderController(GarageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
            return View(orders);
        }

        public IActionResult Create()
        {
            List<int> idList = HttpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) return BadRequest();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Car> Cars = idList.Select(id => _context.Cars.Find(id)).ToList();
            Order newOrder = new Order()
            {
                OrderDate = DateTime.Now,
                IdsCars = JsonSerializer.Serialize(idList),
                TotalPrice = (decimal)Cars.Sum(p => p.Price),
                UserId = userId

            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("mycart");
            return RedirectToAction(nameof(Index));
        }
    }
}
