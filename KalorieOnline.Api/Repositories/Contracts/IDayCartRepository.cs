using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public interface IDayCartRepository
    {
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto);
        Task<CartItem> DeleteItem(int id);
        Task<CartItem> GetItem(int id);
        Task<Cart> AddCart(CartToAddDto cartToAddDto);
        Task<Cart> GetCart(int id);
        Task<Cart> GetCartByUserId(int userId);
        Task<IEnumerable<CartItem>> GetItems(int userId);
    }
}
