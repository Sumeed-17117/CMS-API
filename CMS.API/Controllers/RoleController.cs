using CMS.DBServices.Interfaces;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        IRole _roleSerice;
        public RoleController(IRole role)
        {
            _roleSerice = role;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody]Role role)
        {
            var savedRole = await _roleSerice.CreateRole(role);
            return Ok(savedRole);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            var roleList = await _roleSerice.GetAllRoles();
            return Ok(roleList);
        }
    }
}
