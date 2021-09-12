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
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrder _orders;

        public OrdersController(IMapper mapper, IOrder orders)
        {
            _mapper = mapper;
            _orders = orders;

        }

        [Authorize(Policy = "Customer")]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAProductById(string Id)
        {
            try
            {
                var order = await _orders.GetAOrderDetails(Id);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        //[Authorize(Policy = "Customer")]
        [HttpPost]
        public async Task<IActionResult> AddNewOrder([FromBody] OrderDto model)
        {
            
            
            var neworder = new OrdersModel()
            {
                Amount = model.Amount,
                ShippingAddress = model.ShippingAddress,
                State = model.State,
                ProductId = model.ProductId,
                UserId = model.UserId
                
            };
            try
            {
                var order = await _orders.AddNewOrder(neworder);
                if (order)
                {
                    return Ok();
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
