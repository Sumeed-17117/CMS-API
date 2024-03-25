using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBServices.Interfaces
{
    public interface IRoute
    {
        Task<List<Route>> GetAllRoute();
        Task<Route> GetRouteById(int id);
        Task<Route> SearchCourierByRouteId(int courierRouteId);
        Task<Boolean> DeleteRoute(int id);
        Task<Boolean> UpdateRoute(int id, Route route);
        Task<Route> createPost(Route route);
    }
}
