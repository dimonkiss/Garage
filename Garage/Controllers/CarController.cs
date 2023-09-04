using Microsoft.AspNetCore.Mvc;
using Garage.Models;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage.Controllers
{
    public class CarController : Controller
    {
        private readonly GarageDbContext _context;
        public CarController(GarageDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var cars = _context.Cars.Include(p => p.Category).ToList();
            return View(cars);
        }
        public IActionResult Details(int id)
        {
            var Car = _context.Cars.Include(p=>p.Category).FirstOrDefault(p => p.Id == id);
            return View(Car);
        }
        public IActionResult Delete(int id)
        {

            var Car = _context.Cars.FirstOrDefault(p => p.Id == id);
            if (Car != null)
            {
                _context.Cars.Remove(Car);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index),"Home");
        }
    }
}
