using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos.TreningDtos;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public interface ITreningCartRepository
    {
        Task<TreningCartItem> AddItem(TreningCartItemToAddDto treningCartItemToAddDto);
       
        Task<TreningCartItem> DeleteExercise(int id);
        Task<TreningCartItem> GetExercise(int id);
        Task<TreningCart> AddTreningCart(TreningCartToAddDto cartToAddDto);
        Task<TreningCart> GetTreningCart(int id);
        Task<TreningCartItem> UpdateTreningCart(int id, TreningCartUpdateDto treningCartUpdateDto);
        Task<IEnumerable<TreningCartItem>> GetExercises(int cartId);
        Task<IEnumerable<TreningCart>> GetTreningCartsByUserId(int UserId);

    }
}
