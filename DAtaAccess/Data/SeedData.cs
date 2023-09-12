using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
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
                    Name = "Merdedes CLS 63",
                    Color = "Test",
                    Price = 1000,
                    ImagePath = @"https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Mercedes-Benz_CLS_C218_63_AMG_China_2012-04-15.jpg/1024px-Mercedes-Benz_CLS_C218_63_AMG_China_2012-04-15.jpg"
                    ,
                    CategoryId= 1
                },
                new Car()
                {
                    Id = 2,
                    Name = "Porsche 997",
                    Color = "Test1",
                    Price = 1001,
                    ImagePath = @"https://upload.wikimedia.org/wikipedia/commons/thumb/e/e2/Porsche_Carrera_4S_front_20080519.jpg/1024px-Porsche_Carrera_4S_front_20080519.jpg"
                    ,
                    CategoryId= 2
                },
                new Car()
                {
                    Id = 3,
                    Name = "Audi RS7",
                    Color = "Test2",
                    Price = 1002,
                    ImagePath = @"https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/Audi_RS7_C8_at_IAA_2019_IMG_0307.jpg/1024px-Audi_RS7_C8_at_IAA_2019_IMG_0307.jpg"
                    ,
                    CategoryId = 3
                },
                new Car()
                {
                    Id = 4,
                    Name = "BMW M5",
                    Color = "Test",
                    Price = 1003,
                    ImagePath = @"https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Kunmadaras_Motorsport_2021._szeptember_19._JM_%28157%29.jpg/1024px-Kunmadaras_Motorsport_2021._szeptember_19._JM_%28157%29.jpg"
                    ,
                    CategoryId = 3
                }
            };
        }

        public static List<Category> GetCategory()
        {
            return new List<Category>()
            {
                new Category() { Id = 1,Name="test", Description="test"},
                new Category() { Id = 2,Name="test1", Description="test1"},
                new Category() { Id = 3,Name="test2", Description="test2"}
            };
        }
    }
}
