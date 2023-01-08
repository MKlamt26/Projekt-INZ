using KlalorieOnline.Models.Dtos;

namespace ProjektINZ.Services.Contracts
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseDto>> GetExercises();
        
        Task<ExerciseDto> GetExercise(int id);
    }
}
