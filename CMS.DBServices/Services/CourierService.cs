using CMS.DBServices.Interfaces;
using CMS.Models;
using CMS.Models.DTOS;
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
        public CourierService(ubitse_SampleDBContext context):base(context) 
        {
          
        }
       
        public async Task<Courier> CreateCourier(Courier courier)
        {
           _context.Couriers.Add(courier);
           await _context.SaveChangesAsync();
            return courier;
        }
        public async Task Delete(Courier courier)
        {
            _context.Couriers.Remove(courier);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Courier>> GetAll()
        {
           var ListCouriers = await _context.Couriers.ToListAsync();
           return ListCouriers;
        }
        public async Task<Courier> GetCourierById(int id)
        {
            var FoundCourier = await _context.Couriers.FirstOrDefaultAsync(x =>x.CourierId == id);
            return FoundCourier;
        }

        public async Task<Courier> SearchCourierByCourierName(string courierName)
        {
            var courier = await _context.Couriers.FirstOrDefaultAsync(x => x.CourierName == courierName);
            return courier;
        }

        public async Task Update(Courier courier,Courier courierUpdate)
        {
            courier.CourierName = courierUpdate.CourierName;
            courier.RouteId = courierUpdate.RouteId;
            await _context.SaveChangesAsync();
        }
    }
}
