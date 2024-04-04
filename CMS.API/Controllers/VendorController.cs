using CMS.DBServices.Interfaces;
using CMS.DBServices.Services;
using CMS.Models;
using CMS.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : Controller
    {

        IVendor _vendorService;
        IUser _userService;
        public VendorController(IVendor vendor, IUser userService)
        {
            _vendorService = vendor;
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateVendor")]
        public async Task<IActionResult> CreateVendor([FromBody] VendorDTO vendor)
        {
            User savedUser = null;

            try
            {
                var existinguser = await _userService.GetUserByName(vendor.UserName, vendor.PhoneNumber);
                if (existinguser == null)
                {
                    var newUser = new User
                    {
                        UserName = vendor.UserName,
                        FullName = vendor.VendorName,
                        Email = vendor.VendorEmail,
                        Password = vendor.Password,
                        RoleId = 1002,
                        PhoneNumber = vendor.PhoneNumber
                    };

                    savedUser = await _userService.CreateUser(newUser);
                    var newVendor = new Vendor
                    {
                        VendorName = vendor.VendorName,
                        VendorEmail = vendor.VendorEmail,
                        VendorAddress = vendor.VendorAddress,
                        UserId = savedUser.Id,
                    };
                    await _vendorService.CreateVendor(newVendor);
                    return Ok(new { message = "Vendor Created Successfully" });
                }
                else
                {
                    return Ok(new { message = "User Name/ Phone Number already exist" });
                }
            }
            catch (Exception ex)
            {
                if (savedUser != null)
                {
                    try
                    {
                        await _userService.DeleteUser(savedUser);
                        return BadRequest(ex.Message);
                    }
                    catch (Exception dex)
                    {
                        return BadRequest(dex.Message);
                    }
                    
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        [Route("GetVendors")]
        public async Task<IActionResult> GetAllVendor()
        {
            try
            {
                var vendorList = await _vendorService.GetAllVendor();
                return Ok(vendorList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-Vendor/{VendorId:int}")]
        public async Task<IActionResult> GetById(int VendorId)
        {
            try
            {
                var FoundedVendor = await _vendorService.GetVendorByIdForUpdate(VendorId);
                if (FoundedVendor != null)
                {
                    return Ok(FoundedVendor);
                }
                return NotFound(new { Message = "Vendor Not Found" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        [Route("DeleteVendor/{VendorId:int}")]
        public async Task<IActionResult> DeleteVendor(int VendorId)
        {
            try
            {
                var FoundedVendor = await _vendorService.GetVendorById(VendorId);
                if (FoundedVendor == null)
                {
                    return BadRequest(new { Message = "Vendor Not Found" });
                }
                var userById = await _userService.GetUserById(FoundedVendor.UserId);
                await _userService.DeleteUser(userById);
                await _vendorService.Delete(FoundedVendor);
                return Ok(new { Message = "Vendor Deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateVendor/{VendorId:int}")]
        public async Task<IActionResult> UpdateVendor([FromBody] UpdateVendorDTO vendorUpdate, int VendorId)
        {
            try
            {
                var foundedVendor = await _vendorService.GetVendorById(VendorId);
                if (foundedVendor != null)
                {
                    var foundedUser = await _userService.GetUserById(foundedVendor.UserId);
                    var updateUser = new User
                    {
                        UserName = vendorUpdate.UserName,
                        FullName = vendorUpdate.VendorName,
                        Email = vendorUpdate.VendorEmail,
                        PhoneNumber = vendorUpdate.PhoneNumber,
                    };
                    await _userService.UpdateUser(foundedUser, updateUser);

                    var updateVendor = new Vendor
                    {
                        VendorName = vendorUpdate.VendorName,
                        VendorAddress = vendorUpdate.VendorAddress,
                        VendorEmail = vendorUpdate.VendorEmail,
                    };
                    await _vendorService.Update(foundedVendor, updateVendor);
                    return Ok(new { message = "Vendor updated successfully" });
                }
                else
                {
                    return Ok(new { message = "Vendor Not Found" });
                }
                
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
             };
        }
    }
}
