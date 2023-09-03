using DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required , StringLength(100),MinLength(4)]
        public required string Name { get; set; }
        public string? Color { get; set; }
        public int? Price { get; set; }
        public string? ImagePath { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        //navigation property
        public Category? Category { get; set; }
    }
}
