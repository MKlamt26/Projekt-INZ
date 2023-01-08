using KalorieOnline.Api.Data;
using KalorieOnline.Api.Entities;
using KalorieOnline.Api.Repositories.Contracts;
using KlalorieOnline.Models.Dtos.TreningDtos;
using Microsoft.EntityFrameworkCore;

namespace KalorieOnline.Api.Repositories
{
    public class TreningCartRepository : ITreningCartRepository
    {

        private readonly CaloriesOnlineDbContext caloriesOnlineDbContext;

        public TreningCartRepository(CaloriesOnlineDbContext caloriesOnlineDbContext)
        {
            this.caloriesOnlineDbContext = caloriesOnlineDbContext;
        }
        public async Task<TreningCartItem> AddItem(TreningCartItemToAddDto treningCartItemToAddDto)
        {

        

            var exercise = await this.caloriesOnlineDbContext.Exercises
        .SingleOrDefaultAsync(e => e.Id == treningCartItemToAddDto.ExerciseId);


            TreningCartItem treningCartItem = new TreningCartItem
            {

                CartId = treningCartItemToAddDto.TreningCartId,
                ExerciseId = exercise.Id,

            };

            // dodaj obiekt UserData do bazy danych
           await caloriesOnlineDbContext.TreningCartItems.AddAsync(treningCartItem);
            await caloriesOnlineDbContext.SaveChangesAsync();

            return treningCartItem;
        }

        public async Task<TreningCart> AddTreningCart(TreningCartToAddDto treningcartToAddDto)
        {
            TreningCart TtreningCart = new TreningCart()
            {
                UserId = treningcartToAddDto.UserId,
                CreatedDate = treningcartToAddDto.CreatedDate,
            };




            var result = await this.caloriesOnlineDbContext.TreningCarts.AddAsync(TtreningCart);
            await this.caloriesOnlineDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TreningCartItem> DeleteExercise(int id)
        {
            var exercise = await this.caloriesOnlineDbContext.TreningCartItems.FindAsync(id);

            if (exercise != null)
            {
                this.caloriesOnlineDbContext.TreningCartItems.Remove(exercise);
                await this.caloriesOnlineDbContext.SaveChangesAsync();
            }
            return exercise;
        }

        public async Task<IEnumerable<TreningCartItem>> GetExercises(int cartId)
        {
            return await(from treningCart in this.caloriesOnlineDbContext.TreningCarts
                         join treningCartItem in this.caloriesOnlineDbContext.TreningCartItems
                         on treningCart.Id equals treningCartItem.CartId
                         where treningCart.Id == cartId
                         select new TreningCartItem
                         {
                             Id = treningCartItem.Id,
                             ExerciseId = treningCartItem.ExerciseId,
                             CartId = treningCartItem.CartId,
                             Weight=treningCartItem.Weight,
                             Sets=treningCartItem.Sets,
                             Repetitions=treningCartItem.Repetitions



                         }).ToListAsync();
        }

        public async Task<TreningCartItem> GetExercise(int id)
        {
            return await(from treningCart in this.caloriesOnlineDbContext.TreningCarts
                         join treningCartItem in this.caloriesOnlineDbContext.TreningCartItems
                         on treningCart.Id equals treningCartItem.CartId
                         where treningCartItem.Id == id
                         select new TreningCartItem
                         {
                             Id = treningCartItem.Id,
                             ExerciseId = treningCartItem.ExerciseId,
                             CartId = treningCartItem.Id,
                             Weight = treningCartItem.Weight,
                             Sets = treningCartItem.Sets,
                             Repetitions = treningCartItem.Repetitions

                         }).SingleOrDefaultAsync();
        }

        public async Task<TreningCart> GetTreningCart(int id)
        {
            var cart = await caloriesOnlineDbContext.TreningCarts.Where(c => c.Id == id).FirstOrDefaultAsync();
            return cart;
        }

        public async Task<IEnumerable<TreningCart>> GetTreningCartsByUserId(int UserId)
        {
            var usersDatas = await this.caloriesOnlineDbContext.TreningCarts.Where(ud => ud.UserId == UserId).ToListAsync();
            return usersDatas;
        }

        public async Task<TreningCartItem> UpdateTreningCart(int id, TreningCartUpdateDto treningCartUpdateDto)
        {
            var exercise = await this.caloriesOnlineDbContext.TreningCartItems.FindAsync(id);

            if (exercise != null)
            {
                
                exercise.Sets = treningCartUpdateDto.Sets;
                exercise.Repetitions = treningCartUpdateDto.Repetitions;
                exercise.Weight = treningCartUpdateDto.Wight;


                await this.caloriesOnlineDbContext.SaveChangesAsync();
                return exercise;
            }
            return null;
        }
    }
}
