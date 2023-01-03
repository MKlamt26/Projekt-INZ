using KlalorieOnline.Models.Dtos;
using ShopOnline.Models.Dtos;

namespace ProjektINZ.Services.Contracts
{
    public interface IDayCartService
    {
        Task<IEnumerable<CartItemDto>> GetItems(int cartId);
        Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItemDto> DeleteItem(int id);
        Task<CartItemDto> UpdateQty(CartItemQtyUpdateDto cartItemQtyUpdateDto);

        Task<CartDto> GetCartByUserID(int UserId);
        Task<CartToAddDto> AddCart(CartToAddDto cartToAddDto);
        Task<IEnumerable<CartDto>> GetUserCarts(int userId);
    }
}
