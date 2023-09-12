using DataAccess.Entities;

namespace Garage.Models
{
    public class CarCartViewModel
    {
        public Car Car { get; set; }
        public bool IsInCart { get; set; }
    }
}
