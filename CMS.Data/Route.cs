using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class Route
    {
        public Route()
        {
            Couriers = new HashSet<Courier>();
        }

        public int RouteId { get; set; }
        public string RouteName { get; set; } = null!;

        public virtual ICollection<Courier> Couriers { get; set; }
    }
}
