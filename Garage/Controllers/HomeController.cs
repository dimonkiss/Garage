using DataAccess.Data;
using DataAccess.Models;
using Garage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Garage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GarageDbContext _context;
        public HomeController(ILogger<HomeController> logger, GarageDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? categoryId)
        {
            List<Category> categories = _context.Categories.ToList();
            categories.Insert(0, new Category { Id = 0, Name = "All", Description = "All products" });
            ViewBag.Categories = categories;
            var cars = _context.Cars.Include(cars => cars.Category).ToList(); ;
            if (categoryId != null && categoryId > 0) 
            { 
                cars = _context.Cars.Where(p=>p.CategoryId == categoryId).ToList();
            }
            if(categoryId == null)
            {
                ViewBag.ActiveCategoryId = 0;
            }
            else
            {
                ViewBag.ActiveCategoryId = categoryId;
            }
            return View(cars);
            //return View();
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