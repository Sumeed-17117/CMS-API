using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBServices.Interfaces
{
    public interface IRole
    {
        Task<Role>CreateRole(Role role);

        Task<List<Role>> GetAllRoles();
    }
}
