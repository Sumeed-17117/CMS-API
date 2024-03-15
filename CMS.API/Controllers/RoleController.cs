using CMS.DBServices.Interfaces;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class RoleController : Controller
    {
        IRole _roleService;
        public RoleController(IRole role)
        {
            _roleService = role;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody]Role role)
        {
            var savedRole = await _roleService.CreateRole(role);
            return Ok(savedRole);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRole()
        {
            var roleList = await _roleService.GetAllRoles();
            return Ok(roleList);
        }
    }
}
