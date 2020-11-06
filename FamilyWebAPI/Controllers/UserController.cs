using System;
using System.Threading.Tasks;
using FamilyWebAPI.Data;
using FamilyWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [Route("{username}&{password}")]
        public async Task<ActionResult<User>> LoginAsync([FromRoute] string username, [FromRoute] string password)
        {
            try
            {
                Console.WriteLine("Users called" + username +password);
                User user = await _userService.LoginAsync(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>>RegisterAsync([FromBody] User user)
        {
            Console.WriteLine("Controller add user called");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _userService.RegisterAsync(user);
                return Created($"/{user.Username}", user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}
