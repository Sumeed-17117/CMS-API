using CMS.DBServices.Interfaces;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourierController : Controller
    {
        ICourier _courierService;
        public CourierController(ICourier courier)
        {
            _courierService = courier;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourier([FromBody] Courier courier)
        {
            try
            {
                var savedCourier = await _courierService.CreateCourier(courier);
                return Ok(savedCourier);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet]
        [Route("GetCouriers")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var courierList = await _courierService.GetAll();
                return Ok(courierList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
