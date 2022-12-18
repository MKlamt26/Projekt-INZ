using KalorieOnline.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace KalorieOnline.Api.Data
{
    public class CaloriesOnlineDbContext:DbContext
    {
        public CaloriesOnlineDbContext(DbContextOptions<CaloriesOnlineDbContext> options):base(options)
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
				Calories = 5.8,
				CategoryId = 1
				

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 2,
				Name = "Biały makaron",
				Description = "Ma dużo węglowodanów",
				ImageURL = "/Images/WysokoWęglowodanowe/makaronSpaghetti.jpg",
				Calories = 3.2,
				CategoryId = 2

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 3,
				Name = "Kajzerka",
				Description = "Ma dużo węglowodanów",
				ImageURL = "/Images/WysokoWęglowodanowe/kajzerka.jpg",
				Calories = 3.1,
				CategoryId = 2

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 4,
				Name = "Pierś z Kurczaka",
				Description = "Ma  dużo białka",
				ImageURL = "/Images/WysokoBiałkowe/PierśZkurczaka.jpg",
				Calories = 1.8,
				CategoryId = 3

			});
		
			//Electronics Category
			
			
			
		
			


			//Create Day Cart for Users
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


			// Users Acounts


			modelBuilder.Entity<User>().HasData(new User
			{
				Id = 1,
				UserName = "michal",
				UserPassword = "123"

			});
			modelBuilder.Entity<User>().HasData(new User
			{
				Id=2,
				UserName = "natalia",
				UserPassword = "321"

			});



		}

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserData> userDatas { get; set; }
		

	}
}
