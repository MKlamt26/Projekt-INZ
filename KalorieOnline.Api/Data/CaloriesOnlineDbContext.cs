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
				Name = "Butter",
				Description = "Butter has a lot of saturated fat, limit its consumption",
				ImageURL = "/Images/HighFat/Butter.jpg",
				Calories = 7.35,
				Carbo=0.007,
				Protein=0.007,
				Fat=0.825,
				CategoryId = 1
				

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 2,
				Name = "Pasta",
				Description = "Pasta contains a lot of carbohydrates",
				ImageURL = "/Images/HighCarbohydrates/Pasta.jpg",
				Calories = 3.57,
				Carbo = 0.87,
				Protein = 0.045,
				Fat = 0.021,
				CategoryId = 2

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 3,
				Name = "Roll",
				Description = "Roll has a lot of carbohydrates",
				ImageURL = "/Images/HighCarbohydrates/Roll.jpg",
				Calories = 2.97,
				Carbo = 0.567,
				Protein = 0.092,
				Fat = 0.036,
				CategoryId = 2

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 4,
				Name = "Chicken breast",
				Description = "Chicken breast is high in protein and low in fat",
				ImageURL = "/Images/HighProtein/ChickenBreast.jpg",
				Calories = 0.98,
				Carbo = 0.0,
				Protein = 0.215,
				Fat = 0.013,
				CategoryId = 3

			});
		
			//Electronics Category
			
			
			
		
			


			//Create Day Cart for Users
			//modelBuilder.Entity<Cart>().HasData(new Cart
			//{
			//	Id = 1,
			//	UserId = 1,
			//	CreatedDate=DateTime.Now

			//});
			//modelBuilder.Entity<Cart>().HasData(new Cart
			//{
			//	Id = 2,
			//	UserId = 2,
			//	CreatedDate = DateTime.Now

			//});
			//Add Product Categories
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 1,
				Name = "High_Fat"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 2,
				Name = "High_Carbo"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 3,
				Name = "High_protein"
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
