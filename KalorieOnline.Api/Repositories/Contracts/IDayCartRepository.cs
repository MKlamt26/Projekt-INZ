using KalorieOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public interface IDayCartRepository
    {
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto);
        Task<CartItem> DeleteItem(int id);
        Task<CartItem> GetItem(int id);
        Task<IEnumerable<CartItem>> GetItems(int userId);
    }
}
