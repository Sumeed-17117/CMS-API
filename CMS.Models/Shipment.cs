using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentsBookeds = new HashSet<ShipmentsBooked>();
        }

        public int ShipmentId { get; set; }
        public string ShipmentPrice { get; set; } = null!;
        public double ShipmentWeight { get; set; }
        public string ShipmentAddress { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public int? VendorId { get; set; }

        public virtual Vendor? Vendor { get; set; }
        public virtual ICollection<ShipmentsBooked> ShipmentsBookeds { get; set; }
    }
}
