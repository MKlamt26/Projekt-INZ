using KlalorieOnline.Models.Dtos;
using KlalorieOnline.Models.Dtos.TreningDtos;

namespace ProjektINZ.Services.Contracts
{
    public interface ITreningCartService
    {


        Task<IEnumerable<TreningCartItemDto>> GetExercises(int cartId);
        Task<TreningCartItemDto> AddExercise(TreningCartItemToAddDto treningCartItemToAddDto);
        Task<TreningCartItemDto> DeleteItem(int id);
        Task<TreningCartItemDto> UpdateTreningCart(TreningCartUpdateDto treningCartUpdateDto);

        
        Task<TreningCartToAddDto> AddTreningCart(TreningCartToAddDto treningCartToAddDto);
        Task<IEnumerable<TreningCartDto>> GetUserTreningCarts(int userId);
    }
}
