using System;
using System.Collections.Generic;

namespace CMS.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
