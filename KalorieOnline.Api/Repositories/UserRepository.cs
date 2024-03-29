﻿using KalorieOnline.Api.Data;
using KalorieOnline.Api.Entities;
using KalorieOnline.Api.Repositories.Contracts;
using KlalorieOnline.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace KalorieOnline.Api.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly CaloriesOnlineDbContext caloriesOnlineDbContext;

        public UserRepository(CaloriesOnlineDbContext caloriesOnlineDbContext)
        {
            this.caloriesOnlineDbContext = caloriesOnlineDbContext;
        }

        public async Task<User> AddUser(UserAddDto userToAddDto)
        {
            User user = new User
            {
              
               UserName = userToAddDto.UserName,
               UserPassword = userToAddDto.UserPassword,

            };

            // dodaj obiekt UserData do bazy danych
            caloriesOnlineDbContext.Users.Add(user);
            await caloriesOnlineDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUser(string userName)
        {
            
            var user = await caloriesOnlineDbContext.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await this.caloriesOnlineDbContext.Users.ToListAsync();
            return users;
        }

    }
}
