using CMS.DBServices.Interfaces;
using CMS.DBServices.Services;
using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

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
                var existingCourier = await _courierService.SearchCourierByCourierName(courier.CourierName);

                if (existingCourier != null)
                {
                    return Conflict(new { Message = "Courier Already Exist" });
                }
                else
                {
                    var savedCourier = await _courierService.CreateCourier(courier);
                    return Ok(savedCourier);
                }
            }
            catch (Exception ex)
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

        [HttpGet]
        [Route("GetCourier/{CourierId:int}")]
        public async Task<IActionResult> GetById(int CourierId)
        {
            try
            {
                var FoundedCourier = await _courierService.GetCourierById(CourierId);
                if (FoundedCourier != null)
                {
                    return Ok(FoundedCourier);
                }
                return NotFound(new { Message = "Courier Not Found" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteCourier/{CourierId:int}")]
        public async Task<IActionResult> DeleteCourier(int CourierId)
        {
            try
            {
                var FoundedCourier = await _courierService.GetCourierById(CourierId);
                if (FoundedCourier == null)
                {
                    return BadRequest(new { Message = "Courier Not Found" });
                }
                await _courierService.Delete(FoundedCourier);
                return Ok(new { Message = "Courier Deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateCourier/{CourierId:int}")]
        public async Task<IActionResult> UpdateCourier([FromBody] Courier courierUpdate, int CourierId)
        {
            try
            {
                var FoundedCourier = await _courierService.GetCourierById(CourierId);
                if (FoundedCourier == null)
                {
                    return BadRequest(new { Message = "Courier Not Found" });
                }
                await _courierService.Update(FoundedCourier, courierUpdate);
                return Ok(new { Message = "Courier Updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
