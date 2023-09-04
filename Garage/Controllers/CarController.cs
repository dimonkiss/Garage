using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Garage.Models;

namespace ShopMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly GarageDbContext _context;
        public ProductController(GarageDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            ViewBag.ListCategories = categories;
            ViewData["ListCategories"] = categories;
            //TODO: dbcontext
            var Cars = _context.Cars.Include(p => p.Category).ToList();
            return View(Cars);
        }
        public IActionResult Details(int? id)
        {
            //find in DataBase
            var car= _context.Cars.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (car== null) return NotFound();
            return View(car);
        }

        public IActionResult Delete(int? id)
        {
            //find in DataBase
            var car= _context.Cars.FirstOrDefault(p => p.Id == id);
            if (car!= null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(Index), "Home");
            // return Redirect("~/Home/Index");


        }
    }
}
