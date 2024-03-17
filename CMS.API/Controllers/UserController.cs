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

        [HttpPost]
        [Route("Login-User")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var user = await _userService.SearchUserByUsername(loginDTO.UserName);
                if (user != null )
                {
                    var pass = _userService.DecryptPassword(user.Password, loginDTO.Password);
                    if (pass)
                    {
                        var jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
                        var cred = new SigningCredentials(jwtKey, SecurityAlgorithms.HmacSha256);
                        var claims = new List<Claim>
                        {
                          new Claim("UserId", user.Id.ToString()),
                          new Claim("RoleId", user.RoleId.ToString())
                        };
                        var sToken = new JwtSecurityToken(_options.Key, _options.Issuer, claims, expires: DateTime.Now.AddHours(5), signingCredentials: cred);
                        var token = new JwtSecurityTokenHandler().WriteToken(sToken);
                        return Ok(new {userId=user.Id,roleId=user.RoleId, token = token});
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

        [HttpGet]
        [Authorize]
        public IActionResult userDetail()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userIdClaim = identity.Claims.FirstOrDefault(o=>o.Type == "UserId")?.Value;
            var roleId = identity.Claims.FirstOrDefault(o => o.Type == "RoleId")?.Value;
            return Ok(new { Username = userIdClaim,RoleId = roleId });
        }
    }
}
