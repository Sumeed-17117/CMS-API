using CMS.DBServices.Interfaces;
using CMS.DBServices.Services;
using CMS.Models;
using CMS.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace CMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourierController : Controller
    {
        ICourier _courierService;
        IUser _userService;
        IRoute _routeService;
        public CourierController(ICourier courier, IUser user, IRoute routeService)
        {
            _courierService = courier;
            _userService = user;
            _routeService = routeService;
        }

        [HttpPost]
        [Route("Create-Courier")]
        public async Task<IActionResult> CreateCourier([FromBody] CourierDTO courier)
        {
            User savedUser = null;
            try
            {
                var existingUser = await _userService.GetUserByName(courier.Username, courier.PhoneNumber);
                if (existingUser == null)
                {
                    var newUser = new User
                    {
                        FullName = courier.CourierName,
                        UserName = courier.Username,
                        Email = courier.Email,
                        PhoneNumber = courier.PhoneNumber,
                        RoleId = 2,
                        Password = courier.Password
                    };
                    savedUser = await _userService.CreateUser(newUser);
                    var newCourier = new Courier
                    {
                        CourierName = courier.CourierName,
                        RouteId = (int)courier.RouteId,
                        UserId = savedUser.Id,
                    };
                    await _courierService.CreateCourier(newCourier);
                    return Ok(new { message = "Courier Created Successfully" });
                }
                else
                {
                    return Conflict(new { message = "Username/PhoneNumber Already associated with an Account" });
                }



            }
            catch (Exception ex)
            {
                if (savedUser != null)
                {
                    try
                    {
                        await _userService.DeleteUser(savedUser);
                    }
                    catch (Exception dex)
                    {
                        return BadRequest(dex.Message);
                    }
                }
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
        public async Task<IActionResult> UpdateCourier([FromBody] CourierDTO courierUpdate, int CourierId)
        {
            try
            {
                var foundedCourier = await _courierService.GetById(CourierId);
                if (foundedCourier != null)
                {
                    var user = await _userService.GetUserById(foundedCourier.UserId);
                    if (user != null)
                    {
                        var newUser = new User
                        {
                            FullName = courierUpdate.CourierName,
                            UserName = courierUpdate.Username,
                            Email = courierUpdate.Email,
                            PhoneNumber = courierUpdate.PhoneNumber,
                        };

                        await _userService.UpdateUser(user, newUser);
                        var newCourier = new Courier
                        {
                            CourierName = courierUpdate.CourierName,
                            RouteId = (int)courierUpdate.RouteId,
                        };
                        await _courierService.Update(foundedCourier, newCourier);

                        return Ok(new { Message = "Courier Updated" });
                    }
                    else
                    {
                        return BadRequest("User associated with the courier not found.");
                    }
                }
                else
                {
                    return NotFound(new { Message = "Courier Not Found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while updating the courier: " + ex.Message);
            }
        }
    }
}
