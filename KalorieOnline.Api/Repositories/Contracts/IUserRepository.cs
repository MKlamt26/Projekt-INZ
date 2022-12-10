using KalorieOnline.Api.Entities;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public interface IUserRepository
    {

        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string userName);
    }
}
