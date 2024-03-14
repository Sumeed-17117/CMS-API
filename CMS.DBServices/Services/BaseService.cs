using CMS.DBServices.Interfaces;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBServices.Services
{
    public class BaseService<TObject>
    {
        protected ubitse_SampleDBContext _context;

        public BaseService(ubitse_SampleDBContext context)
        {
            _context = context;
        }
    }
}
