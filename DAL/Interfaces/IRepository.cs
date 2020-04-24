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

        int GetUsersId(string username);

        string GetUsersName(int id);
    }
}
