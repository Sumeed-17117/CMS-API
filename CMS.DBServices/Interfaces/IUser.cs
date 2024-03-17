using CMS.Models;
using CMS.Models.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBServices.Interfaces
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<User> SearchUserByUsername(string username);
        string EncryptPassword(string password);
        bool DecryptPassword(string Hashed, string password);



    }
}
