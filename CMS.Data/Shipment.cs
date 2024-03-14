using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class Shipment
    {
        public int ShipmentId { get; set; }
        public string ShipmentPrice { get; set; } = null!;
        public double ShipmentWeight { get; set; }
        public string ShipmentAddress { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public int VendorId { get; set; }
    }
}
