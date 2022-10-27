using KalorieOnline.Api.Entities;
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
                        Qty = product.Qty,
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
                       CartId = cartItem.CartId,
                       Qty = cartItem.Qty,
                       TotalPrice = product.Calories * cartItem.Qty

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
                TotalPrice = product.Calories * product.Qty,
                CartId = cartItem.CartId,
                Qty = product.Qty,

            };
        }


    }
}
