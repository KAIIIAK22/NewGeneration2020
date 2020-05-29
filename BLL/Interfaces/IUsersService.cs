using BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsersService
    {
        Task<bool> IsUserExistAsync(UserDto userDto);
        Task<bool> IsUserExistByNameAsync(UserDto userDto);
        Task<bool> IsUserExistByEmailAsync(UserDto userDto);
        Task<UserDto> FindUserAsync(UserDto userDto);
        Task AddUserAsync(UserDto userDto);
        int GetUsersId(string username);
        Task<UserDto> GetUserByIdAsync(int id);
        Task AddAttemptAsync(AttemptDTO attemptDto);
    }
}
