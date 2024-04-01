using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DTOS
{
    public class VendorDTO
    {
        public string VendorName { get; set; } = null!;
        public string VendorEmail { get; set; } = null!;
        public string VendorAddress { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

    }
}
