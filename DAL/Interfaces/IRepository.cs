using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository
    {
        Task<bool> IsUserExistByNameAsync(string username, string plainPassword);
        Task<bool> IsUserExistByEmailAsync(string email, string plainPassword);
        Task AddUserToDatabaseAsync(string username, string email, string plainPassword);
        Task<User> FindUserAsync(string nickOrEmail, string userPassword);
        int GetUsersIdByName(string username);
        int GetUsersIdByEmail(string userEmail);
        string GetUsersEmail(int id);
        Task AddAttemptToDatabaseAsync(string email, string ipAddress, bool isSuccess);
    }
}
