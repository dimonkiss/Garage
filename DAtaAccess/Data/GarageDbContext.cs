using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using DataAccess.EntitiesConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data
{
    public class GarageDbContext:IdentityDbContext<User>
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


            #region Fluemt API => Configurations
            ////Set Primary Key
            //modelBuilder.Entity<Product>().HasKey(x => x.Id);

            ////Set Property configurations
            //modelBuilder.Entity<Product>()
            //            .Property(x => x.Name)
            //            .HasMaxLength(150)
            //            .IsRequired();

            ////Set Relationship configurations
            //modelBuilder.Entity<Product>()
            //    .HasOne<Category>(x => x.Category)
            //    .WithMany(x => x.Products)
            //    .HasForeignKey(x => x.CategoryId);
            #endregion

            // ApplyConfigurations for Entities 
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopMVCDbContext).Assembly);
            // or 
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());


        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }



    }
}
