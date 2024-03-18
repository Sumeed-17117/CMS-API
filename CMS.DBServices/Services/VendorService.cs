using CMS.DBServices.Interfaces;
using CMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBServices.Services
{
    public class VendorService : BaseService<Vendor>, IVendor
    {
        public VendorService(ubitse_SampleDBContext context) : base(context) { }
        public async Task<Vendor> CreateVendor(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task Delete(Vendor vendor)
        {
           _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Vendor>> GetAllVendor()
        {
            var vendorslist = await _context.Vendors.ToListAsync();
            return vendorslist;
            
        }

        public async Task<Vendor> GetVendorById(int id)
        {
            var FoundVendor = await _context.Vendors.FirstOrDefaultAsync((e) => e.VendorId == id);
            return FoundVendor;
        }

        public async Task<Vendor> SearchVendorByVendorName(string vendorName)
        {
            var vendor = await _context.Vendors.FirstOrDefaultAsync(x => x.VendorName == vendorName);
            return vendor;
        }

        public async Task Update(Vendor vendor, Vendor vendorUpdate)
        {
            vendor.VendorName = vendorUpdate.VendorName;
            vendor.VendorEmail = vendorUpdate.VendorEmail;
            vendor.VendorPassword = vendorUpdate.VendorPassword;
            vendor.VendorAddress = vendorUpdate.VendorAddress;
            await _context.SaveChangesAsync();
        }
    }
}
