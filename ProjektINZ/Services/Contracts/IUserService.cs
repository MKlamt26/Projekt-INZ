using KlalorieOnline.Models.Dtos;
namespace ProjektINZ.Services.Contracts

{
    public interface IUserService
    {
        Task<UserDto> GetUser(string UserName);
        
    }
}
