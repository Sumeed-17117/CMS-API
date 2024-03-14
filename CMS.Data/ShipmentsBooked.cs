using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class ShipmentsBooked
    {
        public int ShipmentBookedId { get; set; }
        public int ShipmentId { get; set; }
        public int CourierId { get; set; }
        public int StatusId { get; set; }
    }
}
