using KalorieOnline.Api.Entities;

namespace KalorieOnline.Api.Repositories.Contracts
{
    public interface IExerciseRepository
    {
        
        Task<IEnumerable<Exercise>> GetExercises();
        
        Task<Exercise> GetItem(int id);
        Task<ExerciseCategory> GetExerciseCategory(int id);
        Task<IEnumerable<ExerciseCategory>> GetExerciseCategories();


    }
}
