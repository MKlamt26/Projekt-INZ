using ShopOnline.Models.Dtos;

namespace ProjektINZ.Services.Contracts
{
    public interface IDayCartService
    {
        Task<IEnumerable<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);
    }
}
