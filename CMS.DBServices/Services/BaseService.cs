using CMS.DBServices.Dbcontext;
using CMS.DBServices.Interfaces;
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
        protected CMSAppDBContext _context;

        public BaseService(CMSAppDBContext context)
        {
            _context = context;
        }
    }
}
