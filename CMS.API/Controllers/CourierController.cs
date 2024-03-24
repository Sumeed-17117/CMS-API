using CMS.DBServices.Interfaces;
using CMS.DBServices.Services;
using CMS.Models;
using CMS.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourierController : Controller
    {
        ICourier _courierService;
        IUser _userService;
        public CourierController(ICourier courier,IUser user)
        {
            _courierService = courier;
            _userService = user;
        }

        [HttpPost]
        [Route("PostCourier")]
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
                var FoundedCourier = await _courierService.GetCourierUserById(CourierId);
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
                var FoundedCourier = await _courierService.GetById(CourierId);
                if (FoundedCourier == null)
                {
                    return BadRequest(new { Message = "Courier Not Found" });
                }
                var user = await _userService.GetUserById(FoundedCourier.UserId);
                await _userService.DeleteUser(user);
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
        public async Task<IActionResult> UpdateCourier([FromBody] CourierResponseDTO courierUpdate, int CourierId)
        {
            try
            {
                var FoundedCourier = await _courierService.GetById(CourierId);
                if (FoundedCourier == null)
                {
                    return BadRequest(new { Message = "Courier Not Found" });
                }

                var user = await _userService.GetUserById(FoundedCourier.UserId);
                User updatedModel = new User
                {
                   UserName = courierUpdate.CourierName,
                   FullName = courierUpdate.FullName,
                   Email = courierUpdate.Email,
          
                };
                await _userService.UpdateUser(user, updatedModel);
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
