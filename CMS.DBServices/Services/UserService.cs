using CMS.DBServices.Interfaces;
using CMS.Models;
using CMS.Models.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DBServices.Services
{
    public class UserService : BaseService<User>, IUser
    {
        public UserService(ubitse_SampleDBContext dBContext):base(dBContext)
        {
            
        }
        public async Task<User> CreateUser(User user)
        {
            var pass = EncryptPassword(user.Password);
            user.Password = pass;
           _context.Users.Add(user);
           await _context.SaveChangesAsync();
           return user;
        }

        public string EncryptPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public bool DecryptPassword(string Hashed, string password)
        {
            byte[] hashBytes = Convert.FromBase64String(Hashed);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<User> SearchUserByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.UserName == username);
            return user;
        }

        public async Task<User> SearchEmailByUserEmail(string email)
        {
            var userEmail = await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
            return userEmail;
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == id);
            return user;
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user,User updatedUser)
        {
            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;
            user.FullName = updatedUser.FullName;
            user.PhoneNumber = updatedUser.PhoneNumber;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByName(string userName,string PhoneNumber)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName || u.PhoneNumber == PhoneNumber);
            return user;
        }

        
    }
}
