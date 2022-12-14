using KalorieOnline.Api.Repositories.Contracts;
using KlalorieOnline.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KalorieOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private readonly IUserDataRepository userDataRepository;
        public UserDataController(IUserDataRepository userDataRepository)
        {
            this.userDataRepository = userDataRepository;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDataDto>> GetUserData(int id)
        {
            try
            {
                var userData = await this.userDataRepository.GetUserData(id);


                if (userData == null)

                {
                    return BadRequest();
                }
                else
                {
                    
                    var userDatataDto = userData;
                    return Ok(userDatataDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }
        [HttpGet("datas/{id:int}")]
        public async Task<ActionResult<IEnumerable<UserDataDto>>> GetUserDatas(int id)
        {
            try
            {
                var userDatas = await this.userDataRepository.GetUserDatas(id);
                

                if (userDatas == null)

                {
                    return NotFound();
                }
                else
                {
                    var userDatatasDto = userDatas;
                    return Ok(userDatatasDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }





        [HttpPost]
        public async Task<ActionResult<UserDataDto>> PostUserData([FromBody] UserDataDto userDataDto)
        {
            var newUserData = await this.userDataRepository.AddUserData(userDataDto);

            if (newUserData == null)
            {
                return NoContent();
            }

            return CreatedAtAction(nameof(GetUserData), new { id = newUserData.Id }, newUserData);
        }
    }
}
