using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class Status
    {
        public Status()
        {
            ShipmentsBookeds = new HashSet<ShipmentsBooked>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<ShipmentsBooked> ShipmentsBookeds { get; set; }
    }
}
