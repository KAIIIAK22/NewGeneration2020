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

        private readonly SQLContext __context = new SQLContext();

        public UsersRepository(SQLContext context)
        {
            __context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<bool> IsUserExistByNameAsync(string username, string plainPassword)
        {

            return await __context.Users.AnyAsync(u => u.Nick == username.Trim().ToLower() && u.Password == plainPassword.Trim());

        }
        public async Task<bool> IsUserExistByEmailAsync(string email, string plainPassword)
        {

            return await __context.Users.AnyAsync(u => u.Email == email.Trim().ToLower() && u.Password == plainPassword.Trim());

        }

        public async Task AddUserToDatabaseAsync(string username, string email, string plainPassword)
        {
            User user = new User { Nick = username, Email = email, Password = plainPassword };
            __context.Users.Add(user);
            __context.SaveChanges();
            Role role = __context.Roles.First(p => p.Name == "user");

            user.Roles.Add(role);
            __context.SaveChanges();

            await __context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await __context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> FindUserAsync(string nickOrEmail, string userPassword)
        {
            return await __context.Users.FirstOrDefaultAsync(u => (u.Email == nickOrEmail || u.Nick == nickOrEmail) && u.Password == userPassword);
        }

        public int GetUsersIdByName(string username)
        {
            return __context.Users.Where(u => u.Nick == username).Select(u => u.Id).FirstOrDefault();
        }

        public int GetUsersIdByEmail(string userEmail)
        {
            return __context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).FirstOrDefault();
        }

        public async Task AddAttemptToDatabaseAsync(string nickOrEmail, string ipAddress, bool isSuccess)
        {

            User user; 
                if(nickOrEmail.Contains("@"))
                user = await __context.Users.FirstOrDefaultAsync(p => p.Email == nickOrEmail);
                else
                user = await __context.Users.FirstOrDefaultAsync(p => p.Nick == nickOrEmail);
            Attempt attempt2 = new Attempt
            {
                TimeStamp = DateTime.Now,
                Success = isSuccess,
                IpAddress = ipAddress,
                User = user
            };
            __context.Attempts.Add(attempt2);
            await __context.SaveChangesAsync();
        }
    }
}
