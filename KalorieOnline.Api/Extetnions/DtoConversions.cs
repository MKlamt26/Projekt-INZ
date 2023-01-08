using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Extetnions
{
    public static  class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,
                                                                IEnumerable<ProductCategory>productCategories)
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Calories = product.Calories,
                        Protein=product.Protein,
                        Carbo=product.Carbo,
                        Fat=product.Fat,
                        CategoryId = product.CategoryId,
                        
                        CategoryName = productCategory.Name
                    }).ToList();

        }
        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem>cartItems,
                                                                    IEnumerable<Product>products)
        {
            return(from cartItem in cartItems 
                   join product in products
                   on cartItem.ProductId equals product.Id
                   select new CartItemDto
                   {
                       Id = cartItem.Id,
                       ProduntId = cartItem.ProductId,
                       ProductName = product.Name,
                       ProductDescription = product.Description,
                       ProductImageUrl = product.ImageURL,
                       Calories = product.Calories,
                       Protein=product.Protein,
                       Carbohydrates=product.Carbo,
                       Fat = product.Fat,
                       CartId = cartItem.CartId,
                       Qty = cartItem.Qty,
                       TotalCalories = product.Calories * cartItem.Qty,
                       TotalCarbo =product.Carbo * cartItem.Qty,
                       TotalProtein=product.Protein * cartItem.Qty,
                       TotalFat=product.Fat * cartItem.Qty

                   }).ToList();
        }


        public static CartItemDto ConvertToDto(this CartItem cartItem,
                                                                   Product product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProduntId = cartItem.ProductId,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageUrl = product.ImageURL,
                Calories = product.Calories,
                Protein=product.Protein,
                Carbohydrates=product.Carbo,
                Fat=product.Fat,
                TotalCarbo=product.Fat*cartItem.Qty,
                TotalProtein=product.Protein*cartItem.Qty,
                TotalFat=product.Fat*cartItem.Qty,
                TotalCalories = product.Calories * cartItem.Qty,
                CartId = cartItem.CartId,
                Qty = cartItem.Qty,

            };
        }





        public static IEnumerable<ExerciseDto> ConvertToDto(this IEnumerable<Exercise> exercises,
                                                               IEnumerable<ExerciseCategory> exerciseCategories)
        {
            return (from exercise in exercises
                    join exercisCategory in exerciseCategories
                    on exercise.CategoryId equals exercisCategory.Id
                    select new ExerciseDto
                    {
                        Id = exercise.Id,                       
                        Description = exercise.Description,                                               
                        CategoryId = exercise.CategoryId,
                        CategoryName= exercisCategory.Name,
                        Weight=exercise.Weight,
                        Name=exercise.Name,
                        Sets=exercise.Sets,
                        Repetitions=exercise.Repetitions,
                        
                    }).ToList();

        }

        public static IEnumerable<TreningCartItemDto> ConvertToDto(this IEnumerable<TreningCartItem> treningCartItems,
                                                                  IEnumerable<Exercise> exercises)
        {
            return (from treningCartItem in treningCartItems
                    join exercise in exercises
                    on treningCartItem.ExerciseId equals exercise.Id
                    select new TreningCartItemDto
                    {
                        Id = treningCartItem.Id,
                        ExerciseId= treningCartItem.ExerciseId,
                        Name= exercise.Name,
                        Description= exercise.Description,
                        Weight= treningCartItem.Weight,
                        Sets= treningCartItem.Sets,
                        Repetitions= treningCartItem.Repetitions,
                        CartId= treningCartItem.CartId,
                        

                    }).ToList();
        }




        public static TreningCartItemDto ConvertToDto(this TreningCartItem treningCartItem,
                                                                   Exercise exercise)
        {
            return new TreningCartItemDto
            {
                Id = treningCartItem.Id,
                ExerciseId = treningCartItem.ExerciseId,
                Name = exercise.Name,
                Weight= treningCartItem.Weight,
                Description = exercise.Description,
                Sets = treningCartItem.Sets,
                Repetitions = treningCartItem.Repetitions,
                CartId= treningCartItem.CartId

            };
        }


    }
}
