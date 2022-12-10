using KalorieOnline.Api.Repositories.Contracts;
using KlalorieOnline.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalorieOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("{UserName}")]

        public async Task<ActionResult<UserDto>> GetUserData(string UserName)
        {
            try
            {
                var userData = await this.userRepository.GetUser(UserName);


                if (userData == null)

                {
                    return BadRequest();
                }
                else
                {
                    var userDto = userData;
                    return Ok(userDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            try
            {
                var users = await this.userRepository.GetUsers();


                if (users == null)

                {
                    return NotFound();
                }
                else
                {
                    var usersDto = users;
                    return Ok(usersDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }
    }
}
