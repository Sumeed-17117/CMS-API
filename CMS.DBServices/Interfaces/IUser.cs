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
        Task<User> SearchEmailByUserEmail(string email);
        string EncryptPassword(string password);
        bool DecryptPassword(string Hashed, string password);
        Task<User> GetUserById(int id);
        Task DeleteUser(User user);
        Task UpdateUser(User user, User updatedUser);
        Task<User> GetUserByName(string UserName);


    }
}
