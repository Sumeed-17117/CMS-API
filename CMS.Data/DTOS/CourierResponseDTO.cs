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
        public int? RouteId { get; set; }

        public string? RouteName { get; set; }
    }
}
