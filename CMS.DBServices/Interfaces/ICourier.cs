using CMS.Models;
using CMS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBServices.Interfaces
{
    public interface ICourier
    {
        Task<Courier> CreateCourier(Courier courier);

        Task<List<CourierResponseDTO>> GetAll();
        Task<Courier> SearchCourierByCourierName (string courierName);
        Task<CourierResponseDTO> GetCourierUserById(int courierId);
        Task<Courier> GetById(int courierId);
        Task Delete(Courier courier);
        Task Update(Courier courier,CourierResponseDTO updateCourier);
       
    }
}
