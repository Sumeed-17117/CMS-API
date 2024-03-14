using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DTOS
{
    public class LoginDTO
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
