using Microsoft.AspNetCore.Mvc;
using Garage.Models;
using Garage.Helper;
namespace Garage.Controllers
{
    public class CarController : Controller
    {
        private readonly List<Car> _Cars = new List<Car>(SeedData.GetCars());
        public IActionResult Index()
        {
            return View(_Cars);
        }
        public IActionResult Details(int id)
        {
            var Car = _Cars.FirstOrDefault(p => p.Id == id);
            return View(Car);
        }
        public IActionResult Delete(int id)
        {

            var Car = _Cars.FirstOrDefault(p => p.Id == id);
            _Cars.Remove(Car);
            return View("Index", _Cars);
        }
    }
}
