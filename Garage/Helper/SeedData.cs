using Garage.Models;
namespace Garage.Helper
{
    public class SeedData
    {
        public static List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    Name = "Test",
                    Color = "Test",
                    Price = 1000
                },
                new Car()
                {
                    Id = 2,
                    Name = "Test1",
                    Color = "Test1",
                    Price = 1001
                },
                new Car()
                {
                    Id = 3,
                    Name = "Test2",
                    Color = "Test2",
                    Price = 1002
                }
            };
        }
    }
}
