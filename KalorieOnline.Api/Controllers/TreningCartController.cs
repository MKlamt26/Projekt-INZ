using KalorieOnline.Api.Repositories.Contracts;
using KlalorieOnline.Models.Dtos;
using KalorieOnline.Api.Extetnions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Models.Dtos;
using KalorieOnline.Api.Entities;
using KlalorieOnline.Models.Dtos.TreningDtos;

namespace KalorieOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreningCartController : ControllerBase
    {

        private readonly ITreningCartRepository treningCartRepository;
        private readonly IExerciseRepository exerciseRepository;

        public TreningCartController(ITreningCartRepository treningCartRepository,
                                    IExerciseRepository exerciseRepository) //pamiętaj o dependency Inject
        {
            this.treningCartRepository = treningCartRepository;
            this.exerciseRepository = exerciseRepository;
        }



        [HttpGet]
        [Route("{cartId}/GetExercises")]

        public async Task<ActionResult<IEnumerable<TreningCartItemDto>>> GetExercises(int cartId)
        {
            try
            {
                var cartExercises = await this.treningCartRepository.GetExercises(cartId);
                if (cartExercises == null)
                {
                    return NoContent();
                }
                var exercises = await this.exerciseRepository.GetExercises();
                if (exercises == null)
                {
                    throw new Exception("No products exist in system");
                }

                var treningCartExercisesDto = cartExercises.ConvertToDto(exercises);

                return Ok(treningCartExercisesDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<TreningCartItemDto>> GetItem(int id)
        {
            try
            {
                var treningCartItem = await this.treningCartRepository.GetExercise(id);
                if (treningCartItem == null)
                {
                    return NotFound();
                }
                var exercise = await exerciseRepository.GetItem(treningCartItem.ExerciseId);

                if (exercise == null)
                {
                    return NotFound();
                }
                var treningCartItemDto = treningCartItem.ConvertToDto(exercise);

                return Ok(treningCartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("/getByTreningCartId{id:int}")]
        public async Task<ActionResult<TreningCart>> GeetTreningCart(int id)
        {
            try
            {
                var tremningCart = await this.treningCartRepository.GetTreningCart(id);


                if (tremningCart == null)

                {
                    return BadRequest();
                }
                else
                {


                    return Ok(tremningCart);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }




        [HttpGet("getCartsByUserId{userId:int}")]
        public async Task<ActionResult<IEnumerable<TreningCartDto>>> GetCartsByUserId(int userId)
        {
            try
            {
                var userCarts = await this.treningCartRepository.GetTreningCartsByUserId(userId);


                if (userCarts == null)

                {
                    return NotFound();
                }
                else
                {
                    var userCartsDto = userCarts;
                    return Ok(userCartsDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }


        [HttpPost("postByUserId")]
        public async Task<ActionResult<TreningCart>> PostTreningCart([FromBody] TreningCartToAddDto treningCartToAddDto)
        {
            var newCart = await this.treningCartRepository.AddTreningCart(treningCartToAddDto);

            if (newCart == null)
            {
                return NoContent();
            }

            return CreatedAtAction(nameof(GeetTreningCart), new { id = newCart.Id }, newCart);
        }


        [HttpPost]
        public async Task<ActionResult<TreningCartItemDto>> PostItem([FromBody] TreningCartItemToAddDto treningCartItemToAddDto)
        {
            try
            {
                var newTreningCartItem = await this.treningCartRepository.AddItem(treningCartItemToAddDto);

                if (newTreningCartItem == null)
                {
                    return NoContent();
                }

                var exercise = await exerciseRepository.GetItem(newTreningCartItem.ExerciseId);

                if (exercise == null)
                {
                    throw new Exception($"Something went wrong when attempting to retrieve product (productId:({treningCartItemToAddDto.ExerciseId})");
                }

                var newCartItemDto = newTreningCartItem.ConvertToDto(exercise);

                return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TreningCartItemDto>> DeleteItem(int id)
        {
            try
            {
                var cartExercise = await this.treningCartRepository.DeleteExercise(id);

                if (cartExercise == null)
                {
                    return NotFound();
                }

                var exercise = await this.exerciseRepository.GetItem(cartExercise.ExerciseId);

                if (exercise == null)
                    return NotFound();

                var cartItemDto = cartExercise.ConvertToDto(exercise);

                return Ok(cartItemDto);
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpPatch("{id:int}")]
        public async Task<ActionResult<TreningCartItemDto>> UpdateTreningCart(int id, TreningCartUpdateDto treningCartUpdateDto)
        {
            try
            {
                var treningCartItem = await this.treningCartRepository.UpdateTreningCart(id, treningCartUpdateDto);
                if (treningCartItem == null)
                {
                    return NotFound();
                }

                var exercise = await exerciseRepository.GetItem(treningCartItem.ExerciseId);

                var cartItemDto = treningCartItem.ConvertToDto(exercise);

                return Ok(cartItemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


    }
}
