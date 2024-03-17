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
    public class CourierService : BaseService<Courier>, ICourier
    {
        public CourierService(ubitse_SampleDBContext context):base(context) { }
       
        public async Task<Courier> CreateCourier(Courier courier)
        {
           _context.Couriers.Add(courier);
           await _context.SaveChangesAsync();
            return courier;
        }

        public async Task<List<Courier>> GetAll()
        {
           var ListCouriers = await _context.Couriers.ToListAsync();
           return ListCouriers;
        }
    }
}
