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
            var item = await (from userDatas in this.shopOnlineDbContext.userDatas
                              

                              select new UserData
                              {
                                  
                                  UserId = userDataDto.UserId,
                                  Age = userDataDto.Age,
                                  Sex = userDataDto.Sex,
                                  Activity = userDataDto.Activity,
                                  
                                  Height = userDataDto.Height,
                                  
                                  Weight = userDataDto.Weight,
                                  

                              }).FirstOrDefaultAsync();


            
                var result = await this.shopOnlineDbContext.userDatas.AddAsync(item);
                await this.shopOnlineDbContext.SaveChangesAsync();
                return result.Entity;
           
               
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
