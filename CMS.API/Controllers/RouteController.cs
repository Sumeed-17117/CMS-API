using CMS.DBServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using CMS.Models;

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        IRoute _routeService;

        public RouteController(IRoute route)
        {
            _routeService = route;
        }

        [HttpGet]
        [Route("GetAllRoute")]
        public async Task <IActionResult> GetRoute() 
        {
            try
            {
                var data = await _routeService.GetAllRoute();
                if (data == null)
                {
                    return Ok(new {Message = "No Route Availble right now"});
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetRouteById/{id:int}")]

        public async Task<IActionResult> GetRoute(int id)
        {
            try
            {
                var data = await _routeService.GetRouteById(id);
                if (data == null)
                {
                    return Ok(new { Message = "Not Found" });
                }
                return Ok(data);    
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteRoute/{id:int}")]

        public async Task<IActionResult> DeleteRoute(int id)
        {
            try
            {
                var data = await _routeService.DeleteRoute(id);
                if (data)
                {
                    return Ok(new { Message = "Deleted Successfully" });
                }

                return Ok(new {Message = "Error occured while deleting"});
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Updateroute/{id:int}")]
        public async Task<IActionResult> UpdateRoute([FromBody] Models.Route data, int id)
        {
            try
            {
                var Data = await _routeService.UpdateRoute(id,data);
                if (Data)
                {
                    return Ok(new { Message = "Updated Successfully" });
                }
                return Ok(new {Message = "Error occured while updating" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}
