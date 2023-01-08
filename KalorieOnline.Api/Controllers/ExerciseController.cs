using KalorieOnline.Api.Repositories.Contracts;
using KlalorieOnline.Models.Dtos;
using KalorieOnline.Api.Extetnions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalorieOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {

        private readonly IExerciseRepository exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseDto>>> GetExercises()
        {
            try
            {
                var exercises = await this.exerciseRepository.GetExercises();
                var exerciseCategories = await this.exerciseRepository.GetExerciseCategories();

                if (exercises == null )

                {
                    return NotFound();
                }
                else
                {
                    var exerciseDtos = exercises.ConvertToDto(exerciseCategories);
                    return Ok(exerciseDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ExerciseDto>> GetExercise(int id)
        {
            try
            {
                var exercise = await this.exerciseRepository.GetItem(id);


                if (exercise == null)

                {
                    return BadRequest();
                }
                else
                {
                    var exercisetDto = exercise;
                    return Ok(exercisetDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }
    }
}
