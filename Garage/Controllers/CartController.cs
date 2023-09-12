using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Garage.Helper;

namespace Garage.Controllers
{
    public class CartController : Controller
    {
        private readonly GarageDbContext _context;
        public CartController(GarageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<int> idList = HttpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) idList = new List<int>();
            List<Car> Cars = idList.Select(id => _context.Cars.Find(id)).ToList();
            return View(Cars);
        }

        public IActionResult Add(int id)
        {
            if (_context.Cars.Find(id) == null) return NotFound();
            List<int> idList = HttpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) idList = new List<int>();
            idList.Add(id); //add id of Car to cart
            HttpContext.Session.SetObject<List<int>>("mycart", idList);
            return RedirectToAction(nameof(Index), "Home");
        }


        public IActionResult Remove(int id)
        {
            if (_context.Cars.Find(id) == null) return NotFound();
            List<int> idList = HttpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) idList = new List<int>();
            idList.Remove(id); //delete id of Car to cart
            HttpContext.Session.SetObject<List<int>>("mycart", idList);
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
