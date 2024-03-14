using CMS.DBServices.Interfaces;
using CMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBServices.Services 
{
    public class RoleSerivces : BaseService<Role>, IRole
    {
        public RoleSerivces(ubitse_SampleDBContext dBContext):base(dBContext)
        {
            
        }
        public async Task<Role> CreateRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var roleList = await _context.Roles.ToListAsync();
            return roleList;
        }
    }
}
