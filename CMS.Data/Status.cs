using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
    }
}
