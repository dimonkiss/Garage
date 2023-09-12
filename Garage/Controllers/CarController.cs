using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Garage.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
namespace Garage.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        private readonly GarageDbContext _context;
        public CarController(GarageDbContext context)
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
        [AllowAnonymous]
        public IActionResult Details(int? id, string returnURL= null)
        {
            //find in DataBase
            var car = _context.Cars.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (car == null) return NotFound();
            ViewBag.ReturnURL = returnURL;
            return View(car);
        }

        public IActionResult Delete(int? id)
        {
            //find in DataBase
            var car = _context.Cars.FirstOrDefault(p => p.Id == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();

            }
            return RedirectToAction(nameof(Index), "Home");
            // return Redirect("~/Home/Index");


        }
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (!ModelState.IsValid)
            {
                var categories = _context.Categories.ToList();
                ViewBag.CategoryList = new SelectList(categories, "Id", "Name");

                return View(car);
            }
                
            _context.Cars.Add(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {

            var Car = _context.Cars.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (Car != null)
            {
                var categories = _context.Categories.ToList();
                ViewBag.ListCategory = new SelectList(categories, "Id", "Name", Car.CategoryId);
                return View(Car);

            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult Edit(Car Car)
        {
            _context.Cars.Update(Car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
