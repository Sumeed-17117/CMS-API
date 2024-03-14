using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class Courier
    {
        public Courier()
        {
            ShipmentsBookeds = new HashSet<ShipmentsBooked>();
        }

        public int CourierId { get; set; }
        public string CourierName { get; set; } = null!;
        public int? RouteId { get; set; }

        public virtual Route? Route { get; set; }
        public virtual ICollection<ShipmentsBooked> ShipmentsBookeds { get; set; }
    }
}
