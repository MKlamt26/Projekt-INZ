using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public interface IUserDataRepository
    {
        Task<UserData> AddUserData(UserDataDto userDataDto);
        Task<IEnumerable<UserData>> GetUserDatas();
        Task<UserData> GetUserData(int id);

    }
}
