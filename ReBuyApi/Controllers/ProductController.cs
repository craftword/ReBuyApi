using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReBuyCore.Interface;
using ReBuyDtos;
using ReBuyModels;

namespace ReBuyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProduct _products;

        public ProductController(IMapper mapper, IProduct products)
        {
            _mapper = mapper;
            _products = products;
        }

        [Authorize(Policy = "Customer")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAProductById(string Id)
        {
            try
            {
                var product = await _products.GetAProductDetails(Id);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Policy = "Customer")]
        [HttpGet("newarrival")]
        public async Task<IActionResult> GetNewArrivalProduct()
        {
            try
            {
                var products = await _products.GetNewArrivalProducts();
                if (products != null)
                {
                    var productMap = _mapper.Map<List<ProductModel>, List<ProductLikesDto>>(products);
                    return Ok(productMap);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [Authorize(Policy = "Customer")]
        [HttpGet("mostviews")]
        public async Task<IActionResult> GetMostViewProduct()
        {
            try
            {
                var products = await _products.GetMostViewProducts();
                if (products != null)
                {
                    var productMap = _mapper.Map<List<ProductModel>, List<ProductLikesDto>>(products);
                    return Ok(productMap);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
