using DataAccess.Data;
using DataAccess.Entities;
using Garage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Garage.Helper;
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
            //Example using Cookies
            //append Cookie
            //HttpContext.Response.Cookies.Append("name", "Tetiana");
            //get Cookie
            //ViewBag.NameAuthor = HttpContext.Request.Cookies["name"];
            //delete Cookie
            //HttpContext.Response.Cookies.Delete("name");
            List<Category> categories = _context.Categories.ToList();
            categories.Insert(0, new Category { Id = 0, Name = "All", Description = "All Cars" });
            ViewBag.Categories = categories;
            var cars = _context.Cars.Include(cars => cars.Category).ToList(); ;
            if (categoryId != null && categoryId > 0) 
            { 
                cars = _context.Cars.Where(p=>p.CategoryId == categoryId).ToList();
            }
            var carsCartViewModel = cars.Select(
                p => new CarCartViewModel
                {
                    Car = p,
                    IsInCart = IsProductInCart(p.Id)
                }
                ).ToList();
            if (categoryId == null)
            {
                ViewBag.ActiveCategoryId = 0;
            }
            else
            {
                ViewBag.ActiveCategoryId = categoryId;
            }
            return View(carsCartViewModel);
            //return View();
        }
        private bool IsProductInCart(int id)
        {
            List<int> idList = HttpContext.Session.GetObject<List<int>>("mycart");
            if (idList == null) return false;
            return idList.Contains(id);
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