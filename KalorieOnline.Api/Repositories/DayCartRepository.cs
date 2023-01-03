using KalorieOnline.Api.Data;
using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public class DayCartRepository : IDayCartRepository
    {
        private readonly CaloriesOnlineDbContext caloriesOnlineDbContext;

        public DayCartRepository(CaloriesOnlineDbContext caloriesOnlineDbContext)
        {
            this.caloriesOnlineDbContext = caloriesOnlineDbContext;
        }

       

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return false;

            //return await this.caloriesOnlineDbContext.CartItems.AnyAsync(c => c.CartId == cartId &&
            //                                                         c.ProductId == productId);

        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if (await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {

                var item = await (from product in this.caloriesOnlineDbContext.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Qty = cartItemToAddDto.Qty
                                  }).SingleOrDefaultAsync();

                if (item != null)
                {
                    var result = await this.caloriesOnlineDbContext.CartItems.AddAsync(item);
                    await this.caloriesOnlineDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            

            return null;
        }

        public async Task<CartItem> DeleteItem(int id)
        {
            var item = await this.caloriesOnlineDbContext.CartItems.FindAsync(id);

            if (item !=null)
            {
                this.caloriesOnlineDbContext.CartItems.Remove(item);
                await this.caloriesOnlineDbContext.SaveChangesAsync();
            }
            return item;

        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in this.caloriesOnlineDbContext.Carts
                          join cartItem in this.caloriesOnlineDbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              CartId = cartItem.Id,
                              Qty = cartItem.Qty
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in this.caloriesOnlineDbContext.Carts
                           join cartItem in this.caloriesOnlineDbContext.CartItems
                           on cart.Id equals cartItem.CartId
                           where cart.UserId==userId
                          select new CartItem
                          {
                              Id= cartItem.Id,
                              ProductId= cartItem.ProductId,
                              Qty= cartItem.Qty,
                              CartId= cartItem.CartId
                              


                          }).ToListAsync();
        }

        public async Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            var item = await this.caloriesOnlineDbContext.CartItems.FindAsync(id);

            if (item !=null)
            {
                item.Qty = cartItemQtyUpdateDto.Qty;
                await this.caloriesOnlineDbContext.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<Cart> AddCart(CartToAddDto cartToAddDto)
        {
            var item = await(from carts in this.caloriesOnlineDbContext.Carts


                             select new Cart
                             {

                                 UserId= cartToAddDto.UserId,
                                 CreatedDate= cartToAddDto.CreatedDate,
                                 
                                 


                             }).FirstOrDefaultAsync();



            var result = await this.caloriesOnlineDbContext.Carts.AddAsync(item);
            await this.caloriesOnlineDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Cart> GetCart(int id)
        {
            var cart = await caloriesOnlineDbContext.Carts.Where(c => c.Id == id).FirstOrDefaultAsync();
            return cart;
        }

        public async Task<Cart> GetCartByUserId(int userId)
        {
            var cart = await caloriesOnlineDbContext.Carts.Where(c => c.UserId == userId).FirstOrDefaultAsync();
            return cart;
        }

        public async Task<IEnumerable<Cart>> GetUserCarts(int UserId)
        {
            var usersDatas = await this.caloriesOnlineDbContext.Carts.Where(ud => ud.UserId == UserId).ToListAsync();
            return usersDatas;
        }
    }
}
