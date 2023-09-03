using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class GarageDbContext:DbContext
    {
        //public GarageDbContext() {
        //    //Database.EnsureDeleted();
        //    //Database.EnsureCreated();

        //}
        public GarageDbContext(DbContextOptions<GarageDbContext> options) : base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        //{
        //    optionbuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Garage;Integrated Security=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(SeedData.GetCategory());
            modelBuilder.Entity<Car>().HasData(SeedData.GetCars());



        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; } 



    }
}
