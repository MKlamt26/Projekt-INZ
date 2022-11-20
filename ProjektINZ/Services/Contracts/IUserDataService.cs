using KlalorieOnline.Models.Dtos;
using ProjektINZ.ViewModels.Calculator;

namespace ProjektINZ.Services.Contracts
{
    public interface IUserDataService
    {
        Task<IEnumerable<UserDataDto>> GetUserDatas(int userId);
        Task<UserDataDto> GetUserData(int id);
        Task<UserDataDto> AddUserData(UserDataDto userDataDto);
        Task<CalculateCalories> Calculate(int id);
    }
}
