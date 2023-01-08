using KlalorieOnline.Models.Dtos;
using ProjektINZ.Services.Contracts;
using System.Net.Http.Json;

namespace ProjektINZ.Services
{
    public class ExerciseService : IExerciseService
    {

        private readonly HttpClient httpClient;

        public ExerciseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<ExerciseDto> GetExercise(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Exercise/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ExerciseDto);

                    }
                    return await response.Content.ReadFromJsonAsync<ExerciseDto>();

                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
        }

        public async Task<IEnumerable<ExerciseDto>> GetExercises()
        {
            try
            {
                var exercises = await this.httpClient.GetFromJsonAsync<IEnumerable<ExerciseDto>>("api/Exercise");
                return exercises;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
