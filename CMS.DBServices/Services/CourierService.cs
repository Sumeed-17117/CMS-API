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
                  (courier, route) => new { courier.courier, route })
      .Join(_context.Users,
            courierRoute => courierRoute.courier.UserId,
            user => user.Id,
            (courierRoute, user) => new CourierResponseDTO
            {
                CourierId = courierRoute.courier.CourierId,
                CourierName = courierRoute.courier.CourierName,
                RouteId = courierRoute.route.RouteId,
                RouteName = courierRoute.route.RouteName,
                FullName = user.FullName,
                UserId = user.Id,
                CreatedAt = user.CreatedAt
            });

            return await ListCouriers.ToListAsync();

        }

        public async Task<Courier> GetById(int courierId)
        {
            var courier = await _context.Couriers.FirstOrDefaultAsync((e) => e.CourierId == courierId);
            return courier;
        }

        public async Task<CourierResponseDTO> GetCourierUserById(int id)
        {
            var courierDetails = await _context.Couriers
          .Where(c => c.CourierId == id)
          .GroupJoin(_context.Routes,
                     courier => courier.RouteId,
                     route => route.RouteId,
                     (courier, routes) => new { courier, routes })
          .SelectMany(x => x.routes.DefaultIfEmpty(),
                      (courier, route) => new { courier.courier, route })
          .Join(_context.Users,
                courierRoute => courierRoute.courier.UserId,
                user => user.Id,
                (courierRoute, user) => new CourierResponseDTO
                {
                    CourierId = courierRoute.courier.CourierId,
                    CourierName = courierRoute.courier.CourierName,
                    RouteId = courierRoute.route.RouteId,
                    RouteName = courierRoute.route.RouteName,
                    FullName = user.FullName,
                    UserId = user.Id,
                    CreatedAt = user.CreatedAt
                })
          .FirstOrDefaultAsync();

            return courierDetails;
        }

        public async Task<Courier> SearchCourierByCourierName(string courierName)
        {
            var courier = await _context.Couriers.FirstOrDefaultAsync(x => x.CourierName == courierName);
            return courier;
        }

  

        public async Task Update(Courier courier,CourierResponseDTO updateCourier)
        {
            courier.CourierName = updateCourier.CourierName;
            courier.RouteId = (int)(updateCourier?.RouteId);
            await _context.SaveChangesAsync();
        }




    }
}
