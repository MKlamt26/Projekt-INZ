using KalorieOnline.Api.Data;
using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public UserDataRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }

       

        

 

        private object await(object p)
        {
            throw new NotImplementedException();
        }

        public async Task<UserData> AddUserData(UserDataDto userDataDto)
        {
            var item = await (from userDatas in this.shopOnlineDbContext.userDatas
                              

                              select new UserData
                              {
                                  
                                  Id = userDataDto.Id,
                                  Age = userDataDto.Age,
                                  Sex = userDataDto.Sex,
                                  Activity = userDataDto.Activity,
                                  DailyRequirementFat = userDataDto.DailyRequirementFat,
                                  DailyRequirementCarbo = userDataDto.DailyRequirementCarbo,
                                  DailyRequirementKcal = userDataDto.DailyRequirementKcal,
                                  DailyRequirementProtein = userDataDto.DailyRequirementProtein,
                                  Height = userDataDto.Height,
                                  UserId = userDataDto.Id,
                                  Weight = userDataDto.Weight,
                                  

                              }).FirstOrDefaultAsync();


            if (item != null)
            {
                var result = await this.shopOnlineDbContext.userDatas.AddAsync(item);
                await this.shopOnlineDbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
               
        }

        public async Task<IEnumerable<UserData>> GetUserDatas()
        {
            var usersDatas = await this.shopOnlineDbContext.userDatas.ToListAsync();
            return usersDatas;
        }

        public async Task<UserData> GetUserData(int id)
        {
            var usersData = await shopOnlineDbContext.userDatas.FindAsync(id);
            return usersData;
        }
    }
}
