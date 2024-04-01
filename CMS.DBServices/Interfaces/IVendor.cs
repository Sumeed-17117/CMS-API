using CMS.Models;
using CMS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBServices.Interfaces
{
    public interface IVendor
    {
        Task<Vendor> CreateVendor(Vendor vendor);
        Task<List<Vendor>> GetAllVendor();
        Task<Vendor> SearchVendorByVendorName(string vendorName);

        Task<Vendor> GetVendorById(int id);

        Task Delete(Vendor vendor);

        Task Update(Vendor vendor, Vendor vendorUpdate);
        Task<UpdateVendorDTO> GetVendorByIdForUpdate(int id);
    }
}
