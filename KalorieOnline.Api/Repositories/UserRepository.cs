using KalorieOnline.Api.Data;
using KalorieOnline.Api.Entities;
using KalorieOnline.Api.Repositories.Contracts;
using KlalorieOnline.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace KalorieOnline.Api.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly CaloriesOnlineDbContext shopOnlineDbContext;

        public UserRepository(CaloriesOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }

        public async Task<User> AddUser(UserAddDto userToAddDto)
        {
            User user = new User
            {
              
               UserName = userToAddDto.UserName,
               UserPassword = userToAddDto.UserPassword,

            };

            // dodaj obiekt UserData do bazy danych
            shopOnlineDbContext.Users.Add(user);
            await shopOnlineDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUser(string userName)
        {
            
            var user = await shopOnlineDbContext.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await this.shopOnlineDbContext.Users.ToListAsync();
            return users;
        }

    }
}
