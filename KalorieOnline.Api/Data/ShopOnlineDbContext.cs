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
				Name = "masło",
				Description = "jest tłuste",
				ImageURL = "/Images/Beauty/Beauty1.png",
				Calories = 100,
				Qty = 100,
				CategoryId = 1
				

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 2,
				Name = "Curology - Skin Care Kit",
				Description = "A kit provided by Curology, containing skin care products",
				ImageURL = "/Images/Beauty/Beauty2.png",
				Calories = 50,
				Qty = 45,
				CategoryId = 1

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 3,
				Name = "Cocooil - Organic Coconut Oil",
				Description = "A kit provided by Curology, containing skin care products",
				ImageURL = "/Images/Beauty/Beauty3.png",
				Calories = 20,
				Qty = 30,
				CategoryId = 1

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 4,
				Name = "Schwarzkopf - Hair Care and Skin Care Kit",
				Description = "A kit provided by Schwarzkopf, containing skin care and hair care products",
				ImageURL = "/Images/Beauty/Beauty4.png",
				Calories = 50,
				Qty = 60,
				CategoryId = 1

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 5,
				Name = "Skin Care Kit",
				Description = "Skin Care Kit, containing skin care and hair care products",
				ImageURL = "/Images/Beauty/Beauty5.png",
				Calories = 30,
				Qty = 85,
				CategoryId = 1

			});
			//Electronics Category
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 6,
				Name = "Air Pods",
				Description = "Air Pods - in-ear wireless headphones",
				ImageURL = "/Images/Electronic/Electronics1.png",
				Calories = 100,
				Qty = 120,
				CategoryId = 3

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 7,
				Name = "On-ear Golden Headphones",
				Description = "On-ear Golden Headphones - these headphones are not wireless",
				ImageURL = "/Images/Electronic/Electronics2.png",
				Calories = 40,
				Qty = 200,
				CategoryId = 3

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 8,
				Name = "On-ear Black Headphones",
				Description = "On-ear Black Headphones - these headphones are not wireless",
				ImageURL = "/Images/Electronic/Electronics3.png",
				Calories = 40,
				Qty = 300,
				CategoryId = 3

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 9,
				Name = "Sennheiser Digital Camera with Tripod",
				Description = "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod",
				ImageURL = "/Images/Electronic/Electronic4.png",
				Calories = 600,
				Qty = 20,
				CategoryId = 3

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 10,
				Name = "Canon Digital Camera",
				Description = "Canon Digital Camera - High quality digital camera provided by Canon",
				ImageURL = "/Images/Electronic/Electronic5.png",
				Calories = 500,
				Qty = 15,
				CategoryId = 3

			});


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
				Name = "Beauty"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 2,
				Name = "Furniture"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 3,
				Name = "Electronics"
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
