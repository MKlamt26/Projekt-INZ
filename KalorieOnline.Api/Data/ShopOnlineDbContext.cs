using KalorieOnline.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace KalorieOnline.Api.Data
{
    public class ShopOnlineDbContext:DbContext
    {
        public ShopOnlineDbContext(DbContextOptions<ShopOnlineDbContext>options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


			//Products
			//Beauty Category
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 1,
				Name = "Masło",
				Description = "jest tłuste",
				ImageURL = "/Images/WysokoTłuszczowe/masło.jpg",
				Calories = 580,
				Qty = 100,
				CategoryId = 1
				

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 2,
				Name = "Biały makaron",
				Description = "Ma dużo węglowodanów",
				ImageURL = "/Images/WysokoWęglowodanowe/makaronSpaghetti.jpg",
				Calories = 320,
				Qty = 45,
				CategoryId = 2

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 3,
				Name = "Kajzerka",
				Description = "Ma dużo węglowodanów",
				ImageURL = "/Images/WysokoWęglowodanowe/kajzerka.jpg",
				Calories = 310,
				Qty = 30,
				CategoryId = 2

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 4,
				Name = "Pierś z Kurczaka",
				Description = "Ma  dużo białka",
				ImageURL = "/Images/WysokoBiałkowe/PierśZkurczaka.jpg",
				Calories = 180,
				Qty = 60,
				CategoryId = 3

			});
		
			//Electronics Category
			
			
			
		
			


			//Create Shopping Cart for Users
			modelBuilder.Entity<Cart>().HasData(new Cart
			{
				Id = 1,
				UserId = 1

			});
			modelBuilder.Entity<Cart>().HasData(new Cart
			{
				Id = 2,
				UserId = 2

			});
			//Add Product Categories
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 1,
				Name = "Wysoko_Tłuszczowe"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 2,
				Name = "Wysoko_Węglowodanowe"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 3,
				Name = "Wysoko_Białkowe"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 4,
				Name = "Shoes"
			});


		}

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<User> Users { get; set; }

	}
}
