using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DTOS
{
    public class CourierDTO
    {
        public string CourierName { get; set; } = null!;
        public string Username { get; set; } = null!;      
        public string Password { get; set; }
        public string? Email { get; set; }
        public int? RouteId { get; set; }
        public string PhoneNumber { get; set; } = null!;
    }
}
