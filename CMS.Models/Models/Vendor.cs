using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int VendorId { get; set; }
        public string VendorName { get; set; } = null!;
        public string VendorEmail { get; set; } = null!;
        public string VendorPassword { get; set; } = null!;
        public string VendorAddress { get; set; } = null!;

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
