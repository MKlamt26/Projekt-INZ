using KalorieOnline.Api.Entities;
using KalorieOnline.Api.Extetnions;
using KalorieOnline.Api.Repositories.Contracts;
using KlalorieOnline.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayCartController : ControllerBase
    {
        private readonly IDayCartRepository dayCartRepository;
        private readonly IProductRepository productRepository;

        public DayCartController(IDayCartRepository dayCartRepository,
                                    IProductRepository productRepository) //pamiętaj o dependency Inject
        {
            this.dayCartRepository = dayCartRepository;
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("{userId}/GetItems")]

        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems(int userId)
        {
            try
            {
                var cartItems = await this.dayCartRepository.GetItems(userId);
                if (cartItems==null)
                {
                    return NoContent();
                }
                var products = await this.productRepository.GetItems();
                if (products==null)
                {
                    throw new Exception("No products exist in system");
                }

                var cartItemsDto = cartItems.ConvertToDto(products);

                return Ok(cartItemsDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }






        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItem = await this.dayCartRepository.GetItem(id);
                if (cartItem == null)
                {
                    return NotFound();
                }
                var product = await productRepository.GetItem(cartItem.ProductId);

                if (product == null)
                {
                    return NotFound();
                }
                var cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("/getByCartId{id:int}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            try
            {
                var cart= await this.dayCartRepository.GetCart(id);


                if (cart == null)

                {
                    return BadRequest();
                }
                else
                {

                    
                    return Ok(cart);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }


       
        [HttpGet("getCartsByUserId{userId:int}")]
        public async Task<ActionResult<IEnumerable<CartDto>>> GetUserCarts(int userId)
        {
            try
            {
                var userDatas = await this.dayCartRepository.GetUserCarts(userId);


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


        [HttpGet("getByUserId{userId:int}")]
        public async Task<ActionResult<CartDto>> GetCartByUserId(int userId)
        {
            try
            {
                var cart = await this.dayCartRepository.GetCartByUserId(userId);


                if (cart == null)

                {
                    return BadRequest();
                }
                else
                {
                    var cartDto = cart;
                    return Ok(cartDto);
                }
            }

            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }
        
        [HttpPost("postByUserId")]
        public async Task<ActionResult<Cart>> PostUserData([FromBody] CartToAddDto cartToAddDto)
        {
            var newCart = await this.dayCartRepository.AddCart(cartToAddDto);

            if (newCart == null)
            {
                return NoContent();
            }

            return CreatedAtAction(nameof(GetCart), new { id = newCart.Id }, newCart);
        }


        [HttpPost]
        public async Task<ActionResult<CartItemDto>> PostItem([FromBody] CartItemToAddDto cartItemToAddDto)
        {
            try
            {
                var newCartItem = await this.dayCartRepository.AddItem(cartItemToAddDto);

                if (newCartItem == null)
                {
                    return NoContent();
                }

                var product = await productRepository.GetItem(newCartItem.ProductId);

                if (product == null)
                {
                    throw new Exception($"Something went wrong when attempting to retrieve product (productId:({cartItemToAddDto.ProductId})");
                }

                var newCartItemDto = newCartItem.ConvertToDto(product);

                return CreatedAtAction(nameof(GetItem), new { id = newCartItemDto.Id }, newCartItemDto);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CartItemDto>> DeleteItem(int id)
        {
            try
            {
                var cartItem = await this.dayCartRepository.DeleteItem(id);

                if (cartItem == null)
                {
                    return NotFound();
                }

                var product = await this.productRepository.GetItem(cartItem.ProductId);

                if (product == null)
                    return NotFound();

                var cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<CartItemDto>> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            try
            {
                var cartItem = await this.dayCartRepository.UpdateQty(id, cartItemQtyUpdateDto);
                if (cartItem == null)
                {
                    return NotFound();
                }

                var product = await productRepository.GetItem(cartItem.ProductId);

                var cartItemDto = cartItem.ConvertToDto(product);

                return Ok(cartItemDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
