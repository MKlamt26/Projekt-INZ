using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public interface IUserDataRepository
    {
        Task<UserData> AddUserData(UserDataDto userDataDto);
        Task<IEnumerable<UserData>> GetUserDatas(int UserId);
        Task<UserData> GetUserData(int UserId);

    }
}
