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
        public VendorController(IVendor vendor)
        {
            _vendorService = vendor;
        }

        [HttpPost]
        [Route("CreateVendor")]
        public async Task<IActionResult> CreateVendor([FromBody] Vendor vendor)
        {
            try
            {
                var existingVendor = await _vendorService.SearchVendorByVendorName(vendor.VendorName);

                if (existingVendor != null)
                {
                    return Conflict(new { Message = "Vendor Already Exist" });
                }
                else
                {
                    var savedVendor = await _vendorService.CreateVendor(vendor);
                    return Ok(savedVendor);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                var FoundedVendor = await _vendorService.GetVendorById(VendorId);
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
        public async Task<IActionResult> UpdateVendor([FromBody] Vendor vendorUpdate, int VendorId)
        {
            try
            {
                var FoundedVendor = await _vendorService.GetVendorById(VendorId);
                if (FoundedVendor == null)
                {
                    return BadRequest(new { Message = "Vendor Not Found" });
                }
                await _vendorService.Update(FoundedVendor, vendorUpdate);
                return Ok(new { Message = "Vendor Updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
