using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DTOS
{
    public class CourierResponseDTO
    {
        public int CourierId { get; set; }
        public string CourierName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public int? RouteId { get; set; }
        public int UserId { get; set; }
        public string? RouteName { get; set; }
        public DateTime? CreatedAt { get; set; }


    }
}
