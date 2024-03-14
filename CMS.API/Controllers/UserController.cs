using CMS.DBServices.Interfaces;
using CMS.Models;
using CMS.Models.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Create-User")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                var savedUser = await _userService.CreateUser(user);
                return Ok(savedUser);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login-User")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var user = await _userService.SearchUserByUsername(loginDTO.UserName);
                if (user != null)
                {
                    var pass = _userService.DecryptPassword(user.Password, loginDTO.Password);
                    if (pass)
                    {
                        return Ok(user);
                    }
                    return NotFound(new { Message = "Wrong Credentials" });
                }
                return NotFound(new { Message = "Wrong Credentials" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
