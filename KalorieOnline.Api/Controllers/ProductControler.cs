﻿using KalorieOnline.Api.Extetnions;
using KalorieOnline.Api.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Models.Dtos;

namespace KalorieOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductControler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this.productRepository.GetItems();
                var productCategories=await this.productRepository.GetCategories();

                if(products==null || productCategories==null)

                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto(productCategories);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetItem(int id)
        {
            try
            {
                var product = await this.productRepository.GetItem(id);
                

                if (product == null )

                {
                    return BadRequest();
                }
                else
                {
                    var productDto = product;
                    return Ok(productDto);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }


        }



        [HttpGet("Search/{SearchTerm}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>>SearchProducts(string SearchTerm)
        {
            return Ok(await productRepository.SearchProducts(SearchTerm));
        }
       
    }
}
