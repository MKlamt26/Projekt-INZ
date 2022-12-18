using KalorieOnline.Api.Data;
using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly CaloriesOnlineDbContext shopOnlineDbContext;

        public UserDataRepository(CaloriesOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }

       

        

 

        private object await(object p)
        {
            throw new NotImplementedException();
        }

        public async Task<UserData> AddUserData(UserDataDto userDataDto)
        {
            
            UserData userData = new UserData
            {
                
                UserId = userDataDto.UserId,
                Age = userDataDto.Age,
                Sex = userDataDto.Sex,
                Activity = userDataDto.Activity,
                CreatedDate = userDataDto.CreatedDate,
                Height = userDataDto.Height,
                Goal= userDataDto.Goal,
                Weight = userDataDto.Weight,

            };

            // dodaj obiekt UserData do bazy danych
            shopOnlineDbContext.userDatas.Add(userData);
            await shopOnlineDbContext.SaveChangesAsync();

            return userData;


        }

        public async Task<IEnumerable<UserData>> GetUserDatas(int Userid)
        {
            var usersDatas = await this.shopOnlineDbContext.userDatas.Where(ud => ud.UserId == Userid).ToListAsync();
            return usersDatas;
        }

        public async Task<UserData> GetUserData(int Userid)
        {
            var usersData = await shopOnlineDbContext.userDatas.FirstOrDefaultAsync(ud => ud.UserId == Userid);

            return usersData;
        }
    }
}
