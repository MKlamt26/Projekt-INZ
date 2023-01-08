using KalorieOnline.Api.Data;
using KalorieOnline.Api.Entities;
using KalorieOnline.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace KalorieOnline.Api.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {

        private readonly CaloriesOnlineDbContext caloriesOnlineDbContext;

        public ExerciseRepository(CaloriesOnlineDbContext caloriesOnlineDbContext)
        {
            this.caloriesOnlineDbContext = caloriesOnlineDbContext;
        }

        public async Task<IEnumerable<ExerciseCategory>> GetExerciseCategories()
        {
            var ExerciseCategories = await this.caloriesOnlineDbContext.ExerciseCategory.ToListAsync();
            return ExerciseCategories;
        }

        public async Task<ExerciseCategory> GetExerciseCategory(int id)
        {
            var exerciseCategory = await caloriesOnlineDbContext.ExerciseCategory.SingleOrDefaultAsync(c => c.Id == id);
            return exerciseCategory;
        }

        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            var products = await this.caloriesOnlineDbContext.Exercises.ToListAsync();
            return products;
        }

        public async Task<Exercise> GetItem(int id)
        {
            var exercise = await caloriesOnlineDbContext.Exercises.FindAsync(id);
            return exercise;
        }
    }
}
