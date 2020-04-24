using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersRepository : IRepository
    {

        private readonly UserContext _context = new UserContext();

        public UsersRepository(UserContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<bool> IsUserExistByNameAsync(string username, string plainPassword)
        {

            return await _context.Users.AnyAsync(u => u.Nick == username.Trim().ToLower() && u.Password == plainPassword.Trim());

        }
        public async Task<bool> IsUserExistByEmailAsync(string email, string plainPassword)
        {

            return await _context.Users.AnyAsync(u => u.Email == email.Trim().ToLower() && u.Password == plainPassword.Trim());

        }

        public async Task AddUserToDatabaseAsync(string username, string email, string plainPassword)
        {
            _context.Users.Add(new User { Nick = username, Email= email, Password = plainPassword});
            _context.SaveChanges();
        }

        public int GetUsersId(string username)
        {
            return _context.Users.Where(u => u.Email == username).Select(u => u.Id).FirstOrDefault();
        }

        public string GetUsersName(int id)
        {
            return _context.Users.Where(u => u.Id == id).Select(u => u.Email).FirstOrDefault();
        }
    }
}
