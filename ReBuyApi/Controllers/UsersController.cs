using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReBuyDtos;
using ReBuyModels;

namespace ReBuyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<UsersModel> _userManager;
        private readonly IMapper _mapper;
        
        public UsersController(UserManager<UsersModel> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            
        }

        [Authorize(Policy = "Customer")]        
        [HttpGet("Id")]
        public async Task<IActionResult> GetAUsersById(string Id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                if (user != null)
                {
                    var userMap = _mapper.Map<UsersModel, UserDto>(user);
                    return Ok(userMap);
                }
                return NotFound();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [Authorize(Policy = "Customer")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto model, string Id)
        {
            try
            {
                var check = await _userManager.FindByIdAsync(Id);
                if (check != null)
                {

                    check.FullName = model.FullName;
                    check.Address = model.Address;
                    check.State = model.State;                    
                    check.PhoneNumber = model.PhoneNumber;
                    check.Gender = model.Gender;


                    var userAdded = await _userManager.UpdateAsync(check);
                    if (userAdded.Succeeded)
                    {

                        return NoContent();
                    }

                    return BadRequest();

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
