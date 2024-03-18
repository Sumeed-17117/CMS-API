using CMS.DBServices.Interfaces;
using CMS.Models;
using CMS.Models.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUser _userService;
        JwtOption _options;
        public UserController(IUser userService,IOptions<JwtOption> options)
        {
            _userService = userService;
            _options = options.Value;

        }

        [HttpPost]
        [Route("Create-User")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                var existingUser = await _userService.SearchUserByUsername(user.UserName);

                if (existingUser != null)
                {
                    return Conflict(new { Message = "Username Already Exist" });
                }
                else
                {
                    var savedUser = await _userService.CreateUser(user);
                    return Ok(savedUser);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
