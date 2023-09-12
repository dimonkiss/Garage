using DataAccess.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Entities
{
    [EntityTypeConfiguration(typeof(CarConfiguration))]
    public class Car
    {
        //[Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Name is required") , StringLength(100),MinLength(4)]
        public required string Name { get; set; }
        public string? Color { get; set; }
        //[Range(0,double.MaxValue)]
        public int? Price { get; set; }
        //[Url, DisplayName("ImageURL")]
        public string? ImagePath { get; set; }
        //[ForeignKey("Category")]
        public int CategoryId { get; set; }
        //navigation property
        public Category? Category { get; set; }
    }
}
