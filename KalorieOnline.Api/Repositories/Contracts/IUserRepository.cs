using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string userName);
        Task<User> AddUser(UserAddDto userToAddDto);
    }
}
