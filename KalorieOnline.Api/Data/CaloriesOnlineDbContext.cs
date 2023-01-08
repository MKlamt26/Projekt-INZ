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


			//Trening carts
			modelBuilder.Entity<TreningCart>().HasData(new TreningCart
			{
				Id = 1,
				UserId=1,
				CreatedDate=DateTime.Now.AddDays(1),
			});

			//Exercises
			modelBuilder.Entity<Exercise>().HasData(new Exercise
			{
				Id=1,
				Name= "deadlift",
				Description= "The deadlift is a multi-joint exercise involving multiple muscle groups",
				Weight=100,
				Sets=1,
				Repetitions=1,
				CategoryId=1
			});

			modelBuilder.Entity<Exercise>().HasData(new Exercise
			{
				Id = 2,
				Name = "squats",
				Description = "An exercise involving the gluteal muscles as well as the muscles of the thighs and calves",
				Weight=80,
				Sets = 1,
				Repetitions = 1,
				CategoryId = 1
			});

			modelBuilder.Entity<Exercise>().HasData(new Exercise
			{
				Id = 3,
				Name = "push-ups",
				Description = "Pushups are an exercise in which a person, keeping a prone position, with the hands palms down under the shoulders," +
                " the balls of the feet on the ground, and the back straight, pushes the body up and lets it down by an alternate straightening and bending of the arms.",
				Weight=0,
				Sets = 1,
				Repetitions = 1,
				CategoryId=2
			});
			modelBuilder.Entity<Exercise>().HasData(new Exercise
			{
				Id = 4,
				Name = "crunches ",
				Description = "Abdominal crunches are designed to tone the core muscles of the body. The exercise aids in strengthening the core muscles, " +
                "improving the posture, and increasing the mobility and flexibility of the muscles.",
				Sets = 1,
				Repetitions = 1,
				CategoryId = 2
			});



			// Exercise category
			modelBuilder.Entity<ExerciseCategory>().HasData(new ExerciseCategory
			{
				Id = 1,
				Name = "Weight training",
				
			});


			modelBuilder.Entity<ExerciseCategory>().HasData(new ExerciseCategory
			{
				Id = 2,
				Name = "Own bodyweight training",

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
		public DbSet<TreningCartItem> TreningCartItems { get; set; }
		public DbSet<TreningCart> TreningCarts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
		public DbSet<ExerciseCategory> ExerciseCategory { get; set; }


	}
}
