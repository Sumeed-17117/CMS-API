using CMS.DBServices.Dbcontext;
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
    public class RouteService : BaseService<Route>, IRoute
    {
        public RouteService(CMSAppDBContext context) : base(context)
        {
        }

        public async Task<List<Route>> GetAllRoute()
        {
            
            var RouteData = await _context.Routes.ToListAsync();
            return RouteData;
        }

        public async Task<Route> GetRouteById(int id)
        {
            var RouteData = await _context.Routes.FirstOrDefaultAsync(x => x.RouteId == id);
            return RouteData;
        }

        public async Task<Boolean> DeleteRoute(int id)
        {
            var RouteData = await GetRouteById(id);
            if (RouteData != null)
            {
                _context.Routes.Remove(RouteData);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Boolean> UpdateRoute(int id, Route route)
        {
            var RouteData = await GetRouteById(id);
            if (RouteData != null)
            {
                RouteData.RouteName = route.RouteName;
               _context.Routes.Update(RouteData);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<Route> createPost(Route route)
        {
            _context.Routes.Add(route);
            await _context.SaveChangesAsync();
            return route;
        }
        public async Task<Route> SearchCourierByRouteId(int courierRouteId)
        {
            var RouteId = await _context.Routes.FirstOrDefaultAsync(x => x.RouteId == courierRouteId);
            return RouteId;
        }
    }
}
