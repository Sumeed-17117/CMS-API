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

        public async Task<List<CourierResponseDTO>> GetAll()
        {
            var ListCouriers = _context.Couriers
                            .GroupJoin(_context.Routes, 
                                       courier => courier.RouteId, 
                                       route => route.RouteId,     
                                       (courier, routes) => new { courier, routes })
                            .SelectMany(x => x.routes.DefaultIfEmpty(), 
                                        (courier, route) => new CourierResponseDTO
                                        {
                                            CourierId = courier.courier.CourierId,
                                            CourierName = courier.courier.CourierName,
                                            RouteId = route.RouteId,
                                            RouteName = route.RouteName
                                        }); ;
            return await ListCouriers.ToListAsync();
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
