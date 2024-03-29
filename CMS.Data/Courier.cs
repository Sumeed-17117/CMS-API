using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class Courier
    {
        public int CourierId { get; set; }
        public string CourierName { get; set; } = null!;
        public int RouteId { get; set; }
        public int UserId { get; set; }
    }
}
